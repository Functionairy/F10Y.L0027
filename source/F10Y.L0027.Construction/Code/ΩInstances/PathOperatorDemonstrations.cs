using System;


namespace F10Y.L0027.Construction
{
    public class PathOperatorDemonstrations : IPathOperatorDemonstrations
    {
        #region Infrastructure

        public static IPathOperatorDemonstrations Instance { get; } = new PathOperatorDemonstrations();


        private PathOperatorDemonstrations()
        {
        }

        #endregion
    }
}
