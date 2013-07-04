using System;
using Gtk;
using System.Net;
using System.Text.RegularExpressions;
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

	protected void OnButton4Clicked (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void OnButton3Clicked (object sender, EventArgs e)
	{
		if (entry2.Text != "") 
		{
			var request = WebRequest.Create(entry2.Text);
			var response = request.GetResponse ();
			{
				using (var stream = response.GetResponseStream())
					using (var reader = new StreamReader(stream))
				{
					string data = reader.ReadToEnd();
					textview1.Buffer.Text = textview1.Buffer.Text.Insert (0, data);
					Console.WriteLine (data);

					//string pattern = @"<span .*<h3.*<a.*>(?<title>.*)</span>";
					string pattern = @"<a href=.*news/[0-9].*>(?<title>.*)</a>";
					var titleExp = new Regex(pattern);
					string title = titleExp.Match (data).Groups ["title"].Value;

					foreach (Match match in titleExp.Matches(data))
					{
						textview2.Buffer.Text = textview2.Buffer.Text.Insert (textview2.Buffer.CursorPosition, match.ToString()+"\n");
					}
				}
			}
		}
	}
}
