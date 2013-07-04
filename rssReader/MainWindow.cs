using System;
using Gtk;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton2Clicked (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		if (entry3.Text != "")
			ReadRssFeed (entry3.Text);
	}

	protected void ReadRssFeed (string rssUrl)
	{
		var request = WebRequest.Create (rssUrl);
		var response = request.GetResponse ();
		using (var stream = response.GetResponseStream())
		using (var reader = new StreamReader(stream)) 
		{
			string data = reader.ReadToEnd ();
			textview8.Buffer.Text = textview8.Buffer.Text.Insert (textview8.Buffer.CursorPosition, data);
			string pattern = @"<title>.*</title>)";
			//<description>.*</description>
			var titleExp = new Regex (pattern);
			//string title = titleExp.Matches
			foreach (Match match in Regex.Matches(data, pattern))
			{
				textview9.Buffer.Text = textview9.Buffer.Text.Insert(textview9.Buffer.CursorPosition, match.ToString() + "\n");
			}

		}
	}
}
