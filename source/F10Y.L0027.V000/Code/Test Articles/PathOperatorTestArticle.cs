using System;

using F10Y.T0010;


namespace F10Y.L0027.V000
{
    /// <summary>
    /// Path operator test article for the functionality method instances in <see cref="L0027.L000.IPathOperator"/>.
    /// </summary>
    [TestArticleMarker]
    public class PathOperatorTestArticle :
        L000.IPathOperatorTestArticleDefinition
    {
        public string Combine(string[] pathParts)
            => Instances.PathOperator.Combine(pathParts);

        public string Resolve(string path)
            => Instances.PathOperator.Resolve(path);

        //public string Combine_ToFilePath(string[] pathParts)
        //{
        //    var output = Instances.PathOperator.Combine_ToFilePath(pathParts);
        //    return output;
        //}

        //public bool Is_FileIndicated(string path)
        //{
        //    var output = Instances.PathOperator.Is_FileIndicated(path);
        //    return output;
        //}

        //public bool Is_Windows(string path)
        //{
        //    var output = Instances.PathOperator.Is_Windows(path);
        //    return output;
        //}
    }
}
