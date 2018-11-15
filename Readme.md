<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/DocumentMerger/Form1.cs) (VB: [Form1.vb](./VB/DocumentMerger/Form1.vb))
* [DocumentsMerger.cs](./CS/DocumentMerger/Helpers/DocumentsMerger.cs) (VB: [DocumentsMerger.vb](./VB/DocumentMerger/Helpers/DocumentsMerger.vb))
* [SectionsMerger.cs](./CS/DocumentMerger/Helpers/SectionsMerger.cs) (VB: [SectionsMerger.vb](./VB/DocumentMerger/Helpers/SectionsMerger.vb))
* [Program.cs](./CS/DocumentMerger/Program.cs) (VB: [Program.vb](./VB/DocumentMerger/Program.vb))
<!-- default file list end -->
# How to merge documents with headers and footers into a single document


<p>You can append the formatted content to the existing document by using the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSubDocument_AppendRtfTexttopic"><u>SubDocument.AppendRtfText Method</u></a>. However, this method allows you to embed only the body of the source document without headers and footers.</p><p>Headers and footers should be embedded manually. This example illustrates how this can be done.</p>

<br/>


