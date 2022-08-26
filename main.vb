' paimon.moe import helper
' https://paimon.moe/wish/import

Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module paimon_moe_helper

	Private Function ParserClipboarUrl() As String
		If Not Clipboard.ContainsText(TextDataFormat.Html) Then
			Return Nothing
		End If

		Dim html As String = Nothing

		Using ms As MemoryStream = Clipboard.GetData("Html Format")
			ms.Position = 0
			Dim bs(ms.Length - 1) As Byte
			ms.Read(bs, 0, bs.Length)
			html = Encoding.UTF8.GetString(bs)
		End Using

		If html = Nothing Then Return Nothing

		Dim m As Match = Regex.Match(html, "^SourceURL:(.+?)$", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
		If m.Success Then
			Return m.Groups(1).Value
		Else
			Return Nothing
		End If
	End Function

	Sub Main()
		Dim alert As String = "Frist open the Genshin wish history, press Ctrl+A and Ctrl+C, then execute this program!" & vbCrLf & "首先打开原神的祈愿历史，然后按下 Ctrl+A 和 Ctrl+C，最后再打开此程序！"

		Dim url As String = ParserClipboarUrl()

		If url = Nothing Then
			Console.WriteLine(alert)
			Console.ReadLine()
		Else
			Console.WriteLine("Copy to Clipboard: " & url)
			Clipboard.SetDataObject(url, True)
			Console.ReadLine()
		End If

	End Sub

End Module
