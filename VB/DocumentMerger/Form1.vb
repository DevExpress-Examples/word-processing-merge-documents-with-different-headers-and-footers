Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DocumentMerger.Helpers
Imports DevExpress.XtraRichEdit.API.Native

Namespace DocumentMerger

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim filenames As List(Of String) = New List(Of String)() From {"Documents\FloatingObjects.rtf", "Documents\CharacterFormatting.rtf", "Documents\HeadersFooters.rtf"}
            Dim mergedDoc As Document = DocumentsMerger.MergeDouments(filenames)
            richEditControl1.RtfText = mergedDoc.RtfText
        End Sub
    End Class
End Namespace
