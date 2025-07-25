using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0005;


namespace F10Y.L0027.Construction
{
    [ScriptsMarker]
    public partial interface IPathScripts
    {
        public async Task Resolve_UnresolvedPath()
        {
            /// Inputs.
            var path_Unresolved =
                Instances.Paths.Unresolved01
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var path_Resolved = Instances.PathOperator.Resolve(path_Unresolved);

            var lines_ForOutput = Instances.EnumerableOperator.From(path_Resolved)
                .Append("=>")
                .Append(path_Unresolved)
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        public async Task Combine_ProjectReferencePaths()
        {
            /// Inputs.
            var projectFilePath =
                Instances.FilePaths_Examples._Raw.N_001
                ;
            var projectReferencePath =
                Instances.RelativePaths._Raw.N_001
                ;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var projectDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(projectFilePath);

            var projectReferenceFilePath = Instances.PathOperator.Combine(
                projectDirectoryPath,
                projectReferencePath);

            var lines_ForOutput = Instances.EnumerableOperator.From(projectReferenceFilePath)
                .Append("=>")
                .Append(projectFilePath)
                .Append(projectReferencePath)
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
