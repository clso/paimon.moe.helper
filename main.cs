// paimon.moe import helper
// https://paimon.moe/wish/import

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace paimon_moe_helper
{
	class Program
	{
		private static string ParserClipboarUrl()
		{
			if( !Clipboard.ContainsText(TextDataFormat.Html) ) {
				return null;
			}

			string html = null;

			using( MemoryStream ms = (MemoryStream)Clipboard.GetData("Html Format") ) {
				ms.Position = 0;
				byte[] bs = new byte[ms.Length - 1];
				ms.Read(bs, 0, bs.Length);
				html = Encoding.UTF8.GetString(bs);
			}

			if( html == null )
				return null;

			Match m = Regex.Match(html, "^SourceURL:(.+?)$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			if( m.Success ) {
				return m.Groups[1].Value;
			} else {
				return null;
			}
		}

		[STAThread]
		static void Main(string[] pars)
		{
			string alert = "Frist open the Genshin wish history, press Ctrl+A and Ctrl+C, then execute this program!\r\n首先打开原神的祈愿历史，然后按下 Ctrl+A 和 Ctrl+C，最后再打开此程序！";

			string url = ParserClipboarUrl();

			if( url == null ) {
				Console.WriteLine(alert);
				Console.ReadLine();
			} else {
				Console.WriteLine("Copy to Clipboard: " + url);
				Clipboard.SetDataObject(url, true);
				Console.ReadLine();
			}
		}
	}
}
