using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentMerger.Helpers;
using DevExpress.XtraRichEdit.API.Native;

namespace DocumentMerger {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            List<string> filenames = new List<string>() {  
                 @"Documents\FloatingObjects.rtf", 
                 @"Documents\CharacterFormatting.rtf",
                 @"Documents\HeadersFooters.rtf"
            };

            Document mergedDoc = DocumentsMerger.MergeDouments(filenames);
            richEditControl1.RtfText = mergedDoc.RtfText;
        }
    }
}
