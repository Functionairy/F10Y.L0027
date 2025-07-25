using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using F10Y.T0010;


namespace F10Y.L0027.V000
{
    [TestClass, TestFixtureMarker]
    public class PathOperatorTestFixture :
        L000.PathOperatorTestFixtureDefinition<PathOperatorTestArticle>
    {
        public override PathOperatorTestArticle TestArticle { get; } = new PathOperatorTestArticle();
    }
}
