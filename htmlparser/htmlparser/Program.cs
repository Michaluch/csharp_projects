using System;
using Gtk;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace htmlparser
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

			var request = WebRequest.Create("http://stackoverflow.com");
			var response = request.GetResponse ();
			{
				using (var stream = response.GetResponseStream())
					using (var reader = new StreamReader(stream))
				{
					string data = reader.ReadToEnd();
					//win.ParseSite (data);
					Console.WriteLine (data);

					var titleExp = new Regex (@"<h1.*>(?<title>.*)</h1>");
					string title = titleExp.Match (data).Groups ["title"].Value;
					Console.WriteLine (title);

					var postExp = new Regex (@"<div class=.*>(?<post>.*)</div>");
					string post = postExp.Match (data).Groups ["post"].Value;
					Console.WriteLine (post); 
					/*var townExp = new Regex(@"<div class=""Header"".*>(?<town>.*)</div>");
					string town = townExp.Match(data).Groups["town"].Value; // Kiev, Ukraine
					Console.WriteLine ("Town is " + town);
body prose twelve columns
					var temperatureExp = new Regex(@"<a.*class=""Charcoal"" title=""Temperature"".*>(?<temp>\d+).*</a>");
					string temperature = temperatureExp.Match(data).Groups["temp"].Value; // 64
					Console.WriteLine ("Temperature is " + temperature);
					*/
				}
			}
			//Console.WriteLine ("Hello World!");
			Console.ReadLine ();
		}
	}
}