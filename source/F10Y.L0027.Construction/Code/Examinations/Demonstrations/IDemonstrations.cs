using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.L0000.Extensions;
using F10Y.T0006;


namespace F10Y.L0027.Construction
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations :
        Q000.IDemonstrations
    {
        public async Task Write_Examples_All()
        {
            /// Inputs.
            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var lines_ForOutput = Instances.EnumerableOperator.From("Example Paths and Path Parts")
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("File Paths")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From("File Path:")
                            .Append(Instances.FilePaths_Examples.Example.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("File Path, Windows:")
                            .Append(Instances.FilePaths_Examples.Example_Windows.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("File Path, Non-Windows:")
                            .Append(Instances.FilePaths_Examples.Example_NonWindows.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("File Path, Rooted:")
                            .Append(Instances.FilePaths_Examples.Example_Rooted.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("File Path, Relative:")
                            .Append(Instances.FilePaths_Examples.Example_Relative.Entab())
                        )
                        .Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("File Names")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From("File Name:")
                            .Append(Instances.FileNames.Example.Entab())
                        ).Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Directory Paths")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From("Directory Path:")
                            .Append(Instances.DirectoryPaths.Example.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Directory Path, Windows:")
                            .Append(Instances.DirectoryPaths.Example_Windows.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Directory Path, Non-Windows:")
                            .Append(Instances.DirectoryPaths.Example_NonWindows.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Directory Path, Rooted:")
                            .Append(Instances.DirectoryPaths.Example_Rooted.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Directory Path, Relative:")
                            .Append(Instances.DirectoryPaths.Example_Relative.Entab())
                        )
                        .Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Directory Names")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From("Directory Name:")
                            .Append(Instances.DirectoryNames.Example.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Current Directory Name:")
                            .Append(Instances.DirectoryNames.Current.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Parent Directory Name:")
                            .Append(Instances.DirectoryNames.Parent.Entab())
                        ).Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Drive Names")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From("Drive Name:")
                            .Append(Instances.DriveNames.Example.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Drive Name, Windows:")
                            .Append(Instances.DriveNames.Example_Windows.Entab())
                        )
                        .Append_Many(Instances.EnumerableOperator.From("Drive Name, Non-Windows:")
                            .Append(Instances.DriveNames.Example_NonWindows.Entab())
                        ).Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Path Part Sets")
                    .Append_BlankLine()
                    .Append_Many(Instances.EnumerableOperator.Empty<string>()
                        .Append_Many(Instances.EnumerableOperator.From(@"C:\Directory01\Directory02\temp.txt")
                            .Append_Many(Instances.PathPartSets.C_Diretory01_Directory02_temp_txt.Entab())
                        )
                        .Entab()
                    )
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        /// <summary>
        /// Writes the set of all drirectory names to a file.
        /// </summary>
        public async Task Write_DirectoryNames_All()
        {
            /// Inputs.
            var driveNames_All = Instances.DriveNameSets.All;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                driveNames_All);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        /// <summary>
        /// Writes the set of all drive names to a file.
        /// </summary>
        public async Task Write_DriveNames_All()
        {
            /// Inputs.
            var driveNames_All = Instances.DriveNameSets.All;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                driveNames_All);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
