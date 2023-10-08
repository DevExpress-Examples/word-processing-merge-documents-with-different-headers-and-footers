Imports System.Collections.Generic
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace DocumentMerger.Helpers

    Public Class DocumentsMerger

        Public Shared Function MergeDouments(ByVal filenames As List(Of String)) As Document
            Dim targetServer As RichEditDocumentServer = New RichEditDocumentServer()
            Dim sourceServer As RichEditDocumentServer = New RichEditDocumentServer()
            Dim targetDoc As Document = targetServer.Document
            Dim sourceDoc As Document = sourceServer.Document
            For i As Integer = 0 To filenames.Count - 1
                sourceServer.LoadDocument(filenames(i))
                targetDoc.Sections(targetDoc.Sections.Count - 1).UnlinkHeaderFromPrevious()
                targetDoc.Sections(targetDoc.Sections.Count - 1).UnlinkFooterFromPrevious()
                Call SectionsMerger.Append(sourceDoc, targetDoc)
                If i = filenames.Count - 1 Then Return targetDoc
                targetDoc.AppendSection()
            Next

            Return targetDoc
        End Function
    End Class
End Namespace
