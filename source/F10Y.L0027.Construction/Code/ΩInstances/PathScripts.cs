using System;


namespace F10Y.L0027.Construction
{
    public class PathScripts : IPathScripts
    {
        #region Infrastructure

        public static IPathScripts Instance { get; } = new PathScripts();


        private PathScripts()
        {
        }

        #endregion
    }
}
