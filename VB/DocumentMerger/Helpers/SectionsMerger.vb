Imports DevExpress.XtraRichEdit.API.Native

Namespace DocumentMerger.Helpers
	Public Class SectionsMerger
		Public Shared Sub Append(ByVal source As Document, ByVal target As Document)
			Dim lastSectionIndexBeforeAppending As Integer = target.Sections.Count - 1
			Dim sourceSectionCount As Integer = source.Sections.Count

			' Append document body
			target.AppendRtfText(source.RtfText)
			target.DifferentOddAndEvenPages = source.DifferentOddAndEvenPages
			For i As Integer = 0 To sourceSectionCount - 1
				Dim sourceSection As Section = source.Sections(i)
				Dim targetSection As Section = target.Sections(lastSectionIndexBeforeAppending + i)

				' Copy header/footer
				AppendHeader(sourceSection, targetSection, HeaderFooterType.Odd)
				AppendFooter(sourceSection, targetSection, HeaderFooterType.Odd)
				AppendHeader(sourceSection, targetSection, HeaderFooterType.Even)
				AppendFooter(sourceSection, targetSection, HeaderFooterType.Even)
				AppendHeader(sourceSection, targetSection, HeaderFooterType.First)
				AppendFooter(sourceSection, targetSection, HeaderFooterType.First)
			Next i
		End Sub

		Private Shared Sub AppendHeader(ByVal sourceSection As Section, ByVal targetSection As Section, ByVal headerFooterType As HeaderFooterType)
			If Not sourceSection.HasHeader(headerFooterType) Then
				Return
			End If

			Dim source As SubDocument = sourceSection.BeginUpdateHeader(headerFooterType)
			Dim target As SubDocument = targetSection.BeginUpdateHeader(headerFooterType)
			target.Delete(target.Range)
			target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting)

			' Delete empty paragraphs
			Dim emptyParagraph As DocumentRange = target.CreateRange(target.Range.End.ToInt() - 1, 1)
			target.Delete(emptyParagraph)

			sourceSection.EndUpdateHeader(source)
			targetSection.EndUpdateHeader(target)
		End Sub

		Private Shared Sub AppendFooter(ByVal sourceSection As Section, ByVal targetSection As Section, ByVal headerFooterType As HeaderFooterType)
			If Not sourceSection.HasFooter(headerFooterType) Then
				Return
			End If

			Dim source As SubDocument = sourceSection.BeginUpdateFooter(headerFooterType)
			Dim target As SubDocument = targetSection.BeginUpdateFooter(headerFooterType)
			target.Delete(target.Range)
			target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting)

			' Delete empty paragraphs
			Dim emptyParagraph As DocumentRange = target.CreateRange(target.Range.End.ToInt() - 1, 1)
			target.Delete(emptyParagraph)

			sourceSection.EndUpdateFooter(source)
			targetSection.EndUpdateFooter(target)
		End Sub
	End Class
End Namespace