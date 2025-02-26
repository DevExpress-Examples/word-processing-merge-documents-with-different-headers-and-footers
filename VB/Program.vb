Imports DocumentMerger.Helpers
Imports System.Diagnostics

Namespace DocumentMerger

    Friend Class Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        Shared Sub Main(ByVal args As String())
            Dim filenames As List(Of String) = New List(Of String)() From {"Documents\FloatingObjects.rtf", "Documents\CharacterFormatting.rtf", "Documents\HeadersFooters.rtf"}
            Dim mergedDoc = DocumentsMerger.MergeDoсuments(filenames, "Merged.docx")
            Dim p = New Process()
            p.StartInfo = New ProcessStartInfo("Merged.docx") With {.UseShellExecute = True}
            p.Start()
        End Sub
    End Class
End Namespace
