using System;


namespace F10Y.L0027.Construction
{
    public class Instances_X1
    {
        public static L0000.IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static L0000.IFileOperator FileOperator => L0000.FileOperator.Instance;
    }

    public class Instances : Instances_X1
    {
        public static Z0011.Z001.IDirectoryNames DirectoryNames => Z0011.Z001.DirectoryNames.Instance;
        public static Z0011.Z001.IDirectoryPaths DirectoryPaths => Z0011.Z001.DirectoryPaths.Instance;
        public static Z0011.Z001.IDriveNames DriveNames => Z0011.Z001.DriveNames.Instance;
        public static Z0011.Z001.IDriveNameSets DriveNameSets => Z0011.Z001.DriveNameSets.Instance;
        public static Z0011.Z001.IFileNames FileNames => Z0011.Z001.FileNames.Instance;
        public static L0004.L000.IFilePaths FilePaths => L0004.L000.FilePaths.Instance;
        public static Z0011.Z001.IFilePaths FilePaths_Examples => Z0011.Z001.FilePaths.Instance;
        public static L0019.INotepadPlusPlusOperator NotepadPlusPlusOperator => L0019.NotepadPlusPlusOperator.Instance;
        public static L0000.IPathOperator PathOperator => L0000.PathOperator.Instance;
        public static Z0011.Z001.IPaths Paths => Z0011.Z001.Paths.Instance;
        public static Z0011.Z001.IPathPartSets PathPartSets => Z0011.Z001.PathPartSets.Instance;
        public static Z0011.Z001.IRelativePaths RelativePaths => Z0011.Z001.RelativePaths.Instance;
    }
}