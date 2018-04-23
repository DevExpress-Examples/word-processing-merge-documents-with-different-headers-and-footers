using DevExpress.XtraRichEdit.API.Native;

namespace DocumentMerger.Helpers {
    public class SectionsMerger {
        public static void Append(Document source, Document target) {
            int lastSectionIndexBeforeAppending = target.Sections.Count - 1;
            int sourceSectionCount = source.Sections.Count;

            // Append document body
            target.AppendRtfText(source.RtfText);

            for (int i = 0; i < sourceSectionCount; i++) {
                Section sourceSection = source.Sections[i];
                Section targetSection = target.Sections[lastSectionIndexBeforeAppending + i];

                // Copy standard header/footer
                AppendHeader(sourceSection, targetSection, HeaderFooterType.Odd);
                AppendFooter(sourceSection, targetSection, HeaderFooterType.Odd);
            }
        }

        private static void AppendHeader(Section sourceSection, Section targetSection, HeaderFooterType headerFooterType) {
            SubDocument source = sourceSection.BeginUpdateHeader(headerFooterType);
            SubDocument target = targetSection.BeginUpdateHeader(headerFooterType);
            target.Delete(target.Range);
            target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting);

            // Delete empty paragraphs
            DocumentRange emptyParagraph = target.CreateRange(target.Range.End.ToInt() - 2, 2);
            target.Delete(emptyParagraph);

            sourceSection.EndUpdateHeader(source);
            targetSection.EndUpdateFooter(target);
        }

        private static void AppendFooter(Section sourceSection, Section targetSection, HeaderFooterType headerFooterType) {
            SubDocument source = sourceSection.BeginUpdateFooter(headerFooterType);
            SubDocument target = targetSection.BeginUpdateFooter(headerFooterType);
            target.Delete(target.Range);
            target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting);
            
            // Delete empty paragraphs
            DocumentRange emptyParagraph = target.CreateRange(target.Range.End.ToInt() - 2, 2);
            target.Delete(emptyParagraph);

            sourceSection.EndUpdateFooter(source);
            targetSection.EndUpdateFooter(target);
        }
    }
}