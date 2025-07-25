using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;
using F10Y.T0013;


namespace F10Y.L0027.V000.L000
{
    [TestFixtureDefinitionMarker]
    public abstract class PathOperatorTestFixtureDefinition<TTestArticle> : TestFixtureBase<TTestArticle>
        where TTestArticle : IPathOperatorTestArticleDefinition
    {
        [TestMethod]
        public void Resolve()
        {
            var path_Unresolved = Instances.Paths.Unresolved01;
            var path_Resolved_Expected = Instances.Paths.Resolved01;

            var path_Resolved_Actual = this.TestArticle.Resolve(path_Unresolved);

            Assert.AreEqual(
                path_Resolved_Expected,
                path_Resolved_Actual);
        }

        [TestMethod]
        public void Combine()
        {
            var pathParts = Instances.ArrayOperator.From(
                Instances.RootPaths.C_Drive,
                Instances.DirectoryNames.Directory01);

            var path = this.TestArticle.Combine(pathParts);

            Assert.AreEqual(
                @"C:\Directory01",
                path);
        }

        //[TestMethod]
        //public void Combine_ToFilePath()
        //{
        //    var expectation = Instances.Expectations.Combine_ToFilePath;

        //    Instances.TestOperator.Test_Function(
        //        this.TestArticle.Combine_ToFilePath,
        //        expectation);
        //}

        //[TestMethod]
        //public void Is_WindowsPath_True()
        //{
        //    //// Explicit setup.
        //    //var path = Instances.Paths.N001;
        //    //var expected = Instances.Values.True;

        //    //var actual = this.TestArticle.Is_Windows(path);

        //    //Assert.AreEqual(expected, actual);

        //    //// Use an expectation.
        //    //var expectation = Instances.Expectations.Is_WindowsPath_True;

        //    //Instances.TestOperator.Test_Function(
        //    //    this.TestArticle.Is_Windows,
        //    //    expectation);

        //    //// Use the full test.
        //    //var test = Instances.TestGenerator.Get_Is_WindowsPath_True(this.TestArticle);

        //    //Instances.TestOperator.Run(test);

        //    // => I like the expectation the best in the context of a test fixture.
        //    var expectation =
        //        Instances.Expectations.Is_WindowsPath_True
        //        //Instances.Expectations.Is_WindowsPath_ShouldFail
        //        ;

        //    Instances.TestOperator.Test_Function(
        //        this.TestArticle.Is_Windows,
        //        expectation);
        //}
    }
}
