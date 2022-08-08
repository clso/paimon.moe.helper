' paimon.moe import helper
' https://paimon.moe/wish/import

Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module paimon_moe_helper

	Sub Main(ByVal pars As String())
		Dim args As New List(Of String)(pars)
		Dim logPath As String = "%userprofile%\AppData\LocalLow\miHoYo\Genshin Impact\output_log.txt"
		If args.Contains("-CN") Then
			logPath = "%userprofile%\AppData\LocalLow\miHoYo\原神\output_log.txt"
		End If
		logPath = Environment.ExpandEnvironmentVariables(logPath)

		If Not File.Exists(logPath) Then
			Console.WriteLine("Cannot find the log file! Make sure to open the wish history first!")
			Console.ReadLine()
			Return
		End If

		Dim fs = New FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
		Dim sr As New StreamReader(fs, Encoding.UTF8)
		Dim log As String = sr.ReadToEnd()
		sr.Close()

		Dim m As Match = Regex.Match(log, "^OnGetWebViewPageFinish:(.+)$", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
		If m.Success Then
			Console.WriteLine("Copy to Clipboard: " & m.Groups(1).Value)
			' ref assembly System.Windows.Forms.dll
			Clipboard.SetDataObject(m.Groups(1).Value, True)

			Beep()
			'Console.Beep()
			'Console.ReadLine()
		Else
			Console.WriteLine("Cannot find the log file! Make sure to open the wish history first!")
			Console.ReadLine()
		End If


	End Sub

End Module
