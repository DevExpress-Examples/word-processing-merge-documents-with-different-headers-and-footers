Imports DocumentMerger.DocumentMerger.Helpers

Namespace DocumentMerger
    Friend Class Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        Shared Sub Main(args As String())
            Dim filenames As New List(Of String) From {
                "Documents\FloatingObjects.rtf",
                "Documents\CharacterFormatting.rtf",
                "Documents\HeadersFooters.rtf"
            }

            Dim mergedDoc As String = DocumentsMerger.MergeDocuments(filenames, "Merged.docx")

            Dim p As New Process()
            p.StartInfo = New ProcessStartInfo("Merged.docx") With {
                .UseShellExecute = True
            }
            p.Start()
        End Sub
    End Class
End Namespace
