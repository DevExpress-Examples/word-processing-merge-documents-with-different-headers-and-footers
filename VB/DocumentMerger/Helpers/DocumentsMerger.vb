Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraRichEdit
Imports System.Data
Imports DevExpress.XtraRichEdit.API.Native

Namespace DocumentMerger.Helpers
	Public Class DocumentsMerger

		Public Shared Function MergeDouments(ByVal filenames As List(Of String)) As Document
			Dim targetServer As New RichEditDocumentServer()
			Dim sourceServer As New RichEditDocumentServer()
			Dim targetDoc As Document = targetServer.Document
			Dim sourceDoc As Document = sourceServer.Document

			For i As Integer = 0 To filenames.Count - 1
				sourceServer.LoadDocument(filenames(i))

				targetDoc.Sections(targetDoc.Sections.Count - 1).UnlinkHeaderFromPrevious()
				targetDoc.Sections(targetDoc.Sections.Count - 1).UnlinkFooterFromPrevious()

				SectionsMerger.Append(sourceDoc, targetDoc)

				If i = filenames.Count - 1 Then
					Return targetDoc
				End If

				targetDoc.AppendSection()
			Next i

			Return targetDoc
		End Function
	End Class
End Namespace
