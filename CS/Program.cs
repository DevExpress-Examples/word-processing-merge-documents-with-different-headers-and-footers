using DocumentMerger.Helpers;
using System.Collections.Generic;
using System.Diagnostics;

namespace DocumentMerger {
    class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            List<string> filenames = new List<string>() {
                 @"Documents\FloatingObjects.rtf",
                 @"Documents\CharacterFormatting.rtf",
                 @"Documents\HeadersFooters.rtf"
            };


            var mergedDoc = DocumentsMerger.MergeDoсuments(filenames, "Merged.docx");


            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"Merged.docx")
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}
