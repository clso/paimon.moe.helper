using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConsoleApplication1
{
	class Program
	{
		[STAThread]
		static void Main(string[] pars)
		{
			List<string> args = new List<string>(pars);
			string logPath = "%userprofile%\\AppData\\LocalLow\\miHoYo\\Genshin Impact\\output_log.txt";
			if( args.Contains("-CN") ) {
				logPath = "%userprofile%\\AppData\\LocalLow\\miHoYo\\原神\\output_log.txt";
			}
			logPath = Environment.ExpandEnvironmentVariables(logPath);

			if( !File.Exists(logPath) ) {
				Console.WriteLine("Cannot find the log file! Make sure to open the wish history first!");
				Console.ReadLine();
				return;
			}

			FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader sr = new StreamReader(fs, Encoding.UTF8);
			string log = sr.ReadToEnd();
			sr.Close();

			MatchCollection mc = Regex.Matches(log, "^OnGetWebViewPageFinish:(.+)$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			Match m;
			if( mc.Count > 0 ) {
				m = mc[mc.Count - 1];
			} else {
				Console.WriteLine("Cannot find the log file! Make sure to open the wish history first!");
				Console.ReadLine();
				return;
			}
			
			if( m.Success ) {
				Console.WriteLine("Copy to Clipboard: " + m.Groups[1].Value);
				// ref assembly System.Windows.Forms.dll
				Clipboard.SetDataObject(m.Groups[1].Value, true);

				System.Media.SystemSounds.Beep.Play();
				//Console.Beep();
				//Console.ReadLine();
			} else {
				Console.WriteLine("Cannot find the log file! Make sure to open the wish history first!");
				Console.ReadLine();
			}
		}
	}
}
