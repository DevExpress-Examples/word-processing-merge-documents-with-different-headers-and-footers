Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace DocumentMerger.Helpers
    Public Class DocumentsMerger
        Public Shared Function MergeDocuments(filenames As List(Of String), outputFileName As String) As String
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
                    targetServer.SaveDocument(outputFileName, DocumentFormat.OpenXml)
                    Return outputFileName
                End If

                targetDoc.AppendSection()
                targetServer.SaveDocument(outputFileName, DocumentFormat.OpenXml)
            Next

            Return outputFileName
        End Function
    End Class
End Namespace
