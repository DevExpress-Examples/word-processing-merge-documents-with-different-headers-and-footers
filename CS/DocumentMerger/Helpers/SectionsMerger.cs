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

                // Copy header/footer
                AppendHeader(sourceSection, targetSection, HeaderFooterType.Odd);
                AppendFooter(sourceSection, targetSection, HeaderFooterType.Odd);
                AppendHeader(sourceSection, targetSection, HeaderFooterType.Even);
                AppendFooter(sourceSection, targetSection, HeaderFooterType.Even);
                AppendHeader(sourceSection, targetSection, HeaderFooterType.First);
                AppendFooter(sourceSection, targetSection, HeaderFooterType.First);
            }
        }

        private static void AppendHeader(Section sourceSection, Section targetSection, HeaderFooterType headerFooterType) {
            if (!sourceSection.HasHeader(headerFooterType)) return;

            SubDocument source = sourceSection.BeginUpdateHeader(headerFooterType);
            SubDocument target = targetSection.BeginUpdateHeader(headerFooterType);
            target.Delete(target.Range);
            target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting);

            // Delete empty paragraphs
            DocumentRange emptyParagraph = target.CreateRange(target.Range.End.ToInt() - 1, 1);
            target.Delete(emptyParagraph);

            sourceSection.EndUpdateHeader(source);
            targetSection.EndUpdateHeader(target);
        }

        private static void AppendFooter(Section sourceSection, Section targetSection, HeaderFooterType headerFooterType) {
            if (!sourceSection.HasFooter(headerFooterType)) return;

            SubDocument source = sourceSection.BeginUpdateFooter(headerFooterType);
            SubDocument target = targetSection.BeginUpdateFooter(headerFooterType);
            target.Delete(target.Range);
            target.InsertDocumentContent(target.Range.Start, source.Range, InsertOptions.KeepSourceFormatting);
            
            // Delete empty paragraphs
            DocumentRange emptyParagraph = target.CreateRange(target.Range.End.ToInt() - 1, 1);
            target.Delete(emptyParagraph);

            sourceSection.EndUpdateFooter(source);
            targetSection.EndUpdateFooter(target);
        }
    }
}