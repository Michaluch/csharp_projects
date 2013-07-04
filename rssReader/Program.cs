using System;
using Gtk;
using System.Text.RegularExpressions;
using System.Net;

namespace rssReader
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
