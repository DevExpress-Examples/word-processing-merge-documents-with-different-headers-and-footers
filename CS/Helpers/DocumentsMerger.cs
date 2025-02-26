using System.Collections.Generic;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace DocumentMerger.Helpers {
    public class DocumentsMerger {

        public static string MergeDoсuments(List<string> filenames, string outputFileName) {
            RichEditDocumentServer targetServer = new RichEditDocumentServer();
            RichEditDocumentServer sourceServer = new RichEditDocumentServer();
            Document targetDoc = targetServer.Document;
            Document sourceDoc = sourceServer.Document;

            for (int i = 0; i < filenames.Count; i++) {
                sourceServer.LoadDocument(filenames[i]);

                targetDoc.Sections[targetDoc.Sections.Count - 1].UnlinkHeaderFromPrevious();
                targetDoc.Sections[targetDoc.Sections.Count - 1].UnlinkFooterFromPrevious();

                SectionsMerger.Append(sourceDoc, targetDoc);

                if (i == filenames.Count - 1)
                {
                    targetServer.SaveDocument(outputFileName, DocumentFormat.OpenXml);
                    return outputFileName;
                }

                targetDoc.AppendSection();
                targetServer.SaveDocument(outputFileName, DocumentFormat.OpenXml);
            }

            return outputFileName;
        }
    }
}
