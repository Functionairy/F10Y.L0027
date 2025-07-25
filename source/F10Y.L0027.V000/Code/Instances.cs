using System;


namespace F10Y.L0027.V000
{
    public static class Instances
    {
        public static L0000.IArrayOperator ArrayOperator => L0000.ArrayOperator.Instance;
        public static Z0011.Z001.IDirectoryNames DirectoryNames => Z0011.Z001.DirectoryNames.Instance;
        public static L0027.L000.IPathOperator PathOperator => L0027.L000.PathOperator.Instance;
        public static Z0011.Z001.IRootPaths RootPaths => Z0011.Z001.RootPaths.Instance;
    }
}