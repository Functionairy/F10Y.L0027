using System;

using F10Y.T0010;


namespace F10Y.L0027.V000.L000
{
    [TestArticleDefinitionMarker]
    public partial interface IPathOperatorTestArticleDefinition
    {
        public string Combine(string[] pathParts);
        public string Resolve(string path);

        //string Combine_ToFilePath(string[] pathParts);
        //bool Is_FileIndicated(string path);
        //bool Is_Windows(string path);
    }
}
