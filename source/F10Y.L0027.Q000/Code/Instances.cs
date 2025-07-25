using System;


namespace F10Y.L0027.Q000
{
    public static class Instances
    {
        public static L0000.IArrayOperator ArrayOperator => L0000.ArrayOperator.Instance;
        public static Z0011.Z001.IDriveNameSets DriveNameSets => Z0011.Z001.DriveNameSets.Instance;
        public static L0000.IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static L0000.IEnvironmentOperator EnvironmentOperator => L0000.EnvironmentOperator.Instance;
        public static Z0011.Z001.IDirectoryNames DirectoryNames => Z0011.Z001.DirectoryNames.Instance;
        public static Z0011.Z001.IDirectoryPaths DirectoryPaths => Z0011.Z001.DirectoryPaths.Instance;
        public static L0001.L000.IDirectorySeparators DirectorySeparators => L0001.L000.DirectorySeparators.Instance;
        public static L0000.IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static L0000.INullOperator NullOperator => L0000.NullOperator.Instance;
        public static L000.IPathOperator PathOperator => L000.PathOperator.Instance;
        public static Z0011.Z001.IPathsSets PathsSets => Z0011.Z001.PathsSets.Instance;
        public static Z0011.Z001.IDirectoryPaths Paths_Directories => Instances.DirectoryPaths;
        public static Z0011.Z001.IPaths Paths => Z0011.Z001.Paths.Instance;
        public static Z0011.Z001.IRootPaths Paths_Roots => Instances.RootPaths;
        public static Z0011.Z001.IRootPaths RootPaths => Z0011.Z001.RootPaths.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0001.L003.ITextOperator TextOperator => L0001.L003.TextOperator.Instance;
    }
}