using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraRichEdit;
using System.Data;
using DevExpress.XtraRichEdit.API.Native;

namespace DocumentMerger.Helpers {
    public class DocumentsMerger {

        public static Document MergeDouments(List<string> filenames) {
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
                    return targetDoc;

                targetDoc.AppendSection();
            }

            return targetDoc;
        }
    }
}
