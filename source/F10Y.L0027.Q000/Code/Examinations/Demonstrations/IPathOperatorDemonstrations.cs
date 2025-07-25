using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using F10Y.L0000.Extensions;
using F10Y.L0001.L000.Extensions;
using F10Y.T0006;


namespace F10Y.L0027.Q000
{
    using IPathOperator = L0000.IPathOperator;


    [DemonstrationsMarker]
    public partial interface IPathOperatorDemonstrations
    {
        #region Infrastructure

        // See F10Y.Q0000.Q001 for another instance of the infrastructure approach.

        /// <summary>
        /// Provides a path for writing output text.
        /// </summary>
        public string Output_TextFilePath { get; }

        /// <summary>
        /// Provides the ability open files for display.
        /// </summary>
        /// <remarks>
        /// This would typically be a text editor like notepad, Notepad++, or VS Code.
        /// </remarks>
        public void Open(params string[] filePaths);

        /// <summary>
        /// Opens the <see cref="Output_TextFilePath"/>.
        /// </summary>
        public void Open_OutputTextFile()
            => this.Open(
                this.Output_TextFilePath);

        #endregion


        public async Task Is_Windows()
        {
            /// Inputs.
            var paths = Instances.PathsSets.All;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var results = paths
                .Select(path =>
                {
                    try
                    {
                        var isWindows = Instances.PathOperator.Is_Platform_Windows(path);

                        return (Path: path, IsWindows: isWindows, Exception: null);
                    }
                    catch (Exception exception)
                    {
                        return (Path: path, IsWindows: false, Exception: exception);
                    }
                })
                .Now();

            var results_NonExceptive = results
                .Where(result => Instances.NullOperator.Is_Null(result.Exception))
                ;

            var results_Windows = results_NonExceptive
                .Where(tuple => tuple.IsWindows)
                ;

            var results_NonWindows = results_NonExceptive
                .Where(tuple => !tuple.IsWindows)
            ;

            var results_Exceptive = results
                .Where(result => Instances.NullOperator.Is_NotNull(result.Exception))
                ;

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Windows, path categorization")
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Windows:")
                    .Append_Many(results_Windows
                        .Select(tuple => Instances.TextOperator.Get_TextRepresentation(tuple.Path))
                        .Order_Alphabetically()
                        .Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Non-Windows:")
                    .Append_Many(results_NonWindows
                        .Select(tuple => Instances.TextOperator.Get_TextRepresentation(tuple.Path))
                        .Order_Alphabetically()
                        .Entab()
                    )
                )
                .Append_BlankLine()
                .Append_Many(Instances.EnumerableOperator.From("Exceptions:")
                    .Append_Many(results_Exceptive
                        .SelectMany(result => Instances.EnumerableOperator.Empty<string>()
                            .Append_BlankLine()
                            .Append($"'{Instances.TextOperator.Get_TextRepresentation(result.Path)}': path")
                            .Append_Many(Instances.StringOperator.Split_Lines(result.Exception.Message)
                                .Entab()
                            )
                        )
                    )
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        /// <summary>
        /// A simple test of two paths, one is a Windows path, one is a non-Windows path.
        /// </summary>
        public async Task Is_Windows_Simple()
        {
            /// Inputs.
            var paths = new[]
            {
                Instances.Paths.Resolved01,
                Instances.Paths.Unresolved01,
            };

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var results = paths
                .Select(path =>
                {
                    var isWindows = Instances.PathOperator.Is_Platform_Windows(path);

                    return (Path: path, Result: isWindows);
                })
                .Now();

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Windows")
                .Append_BlankLine()
                .Append_Many(results
                    .Select(result => $"{result.Result}: {result.Path}")
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        public async Task Is_Resolved()
        {
            /// Inputs.
            var paths = new[]
            {
                Instances.Paths.Resolved01,
                Instances.Paths.Unresolved01,
            };

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var results = paths
                .Select(path =>
                {
                    var isResolved = Instances.PathOperator.Is_Resolved(path);

                    return (Path: path, Result: isResolved);
                })
                .Now();

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Resolved")
                .Append_BlankLine()
                .Append_Many(results
                    .Select(result => $"{result.Result}: {result.Path}")
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        public async Task Split()
        {
            /// Inputs.
            var path = Instances.Paths.Unresolved01;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var pathParts = Instances.PathOperator.Split(path);

            var lines_ForOutput = Instances.EnumerableOperator.From("Split Path")
                .Append_BlankLine()
                .Append(path)
                .Append_BlankLine()
                .Append_Many(pathParts)
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        public async Task Is_RootIndicated()
        {
            /// Inputs.
            var paths =
                new[]
                {
                    Instances.DirectoryNames.Directory01,
                    Instances.DirectoryNames.Directory01_DirectoryIndicated_NonWindows,
                    Instances.DirectoryNames.Directory01_DirectoryIndicated_Windows,
                    Instances.DirectoryNames.Directory01_RootIndicated_NonWindows,
                    Instances.DirectoryNames.Directory01_RootIndicated_Windows,
                    Instances.Paths_Roots.C_Drive_DirectoryIndicated,
                    Instances.Paths_Roots.C_Drive_NonDirectoryIndicated,
                    Instances.Paths.C_Temp_Temp_txt,
                    Instances.Paths.Unresolved01,
                    Instances.Paths.Resolved01
                }
                ;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var results = paths
                .Select(path =>
                {
                    var isRootIndicated = Instances.PathOperator.Is_RootIndicated(path);

                    return (Path: path, Result: isRootIndicated);
                })
                .Now();

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Root Indicated")
                .Append_BlankLine()
                .Append_Many(results
                    .Select(result => $"{result.Result}: {result.Path}")
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        /// <summary>
        /// Demonstrates the <see cref="IPathOperator.Is_RootIndicated(string)"/> method,
        /// on a single string.
        /// </summary>
        public async Task Is_RootIndicated_Single()
        {
            /// Inputs.
            var path =
                Instances.DirectoryNames
                    .Directory01_RootIndicated_NonWindows
                ;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var isRootIndicated = Instances.PathOperator.Is_RootIndicated(path);

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Root Indicated")
                .Append_BlankLine()
                .Append($"{isRootIndicated}: {path}")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        /// <summary>
        /// Demonstrates the <see cref="IPathOperator.Is_DirectoryIndicated(string)"/> method,
        /// on multiple strings.
        /// </summary>
        public async Task Is_DirectoryIndicated()
        {
            /// Inputs.
            var paths = new[]
            {
                Instances.DirectoryNames.Directory01,
                Instances.DirectoryNames.Directory01_DirectoryIndicated_NonWindows,
                Instances.DirectoryNames.Directory01_DirectoryIndicated_Windows,
                Instances.DirectoryNames.Directory01_RootIndicated_NonWindows,
                Instances.DirectoryNames.Directory01_RootIndicated_Windows,
                Instances.DirectoryNames._Raw.N_004_01_5,
            };

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var results = paths
                .Select(path =>
                {
                    var isDirectoryIndicated = Instances.PathOperator.Is_DirectoryIndicated(path);

                    return (Path: path, Result: isDirectoryIndicated);
                })
                .Now();

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Directory Indicated")
                .Append_BlankLine()
                .Append_Many(results
                    .Select(result => $"{result.Result}: {result.Path}")
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        /// <summary>
        /// Demonstrates the <see cref="IPathOperator.Is_DirectoryIndicated(string)"/> method,
        /// on a single string.
        /// </summary>
        public async Task Is_DirectoryIndicated_Single()
        {
            /// Inputs.
            var path =
                Instances.DirectoryNames
                    .Directory01_DirectoryIndicated_NonWindows
                ;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var isDirectoryIndicated = Instances.PathOperator.Is_DirectoryIndicated(path);

            var lines_ForOutput = Instances.EnumerableOperator.From("Is-Directory Indicated")
                .Append_BlankLine()
                .Append($"{isDirectoryIndicated}: {path}")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        /// <summary>
        /// Display the various directory separators.
        /// </summary>
        public async Task Display_DirectorySeparators()
        {
            /// Inputs.
            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var directorySeparator_Windows = Instances.DirectorySeparators.Windows;
            var directorySeparator_NonWindows = Instances.DirectorySeparators.NonWindows;

            var directorySeparator_Environment = Instances.DirectorySeparators.Environment;
            var directorySeparator_Environment_Alternate = Instances.DirectorySeparators.Environment_Alternate;

            var directorySeparator_Standard = Instances.DirectorySeparators.Standard;

            var environmentName = Instances.EnvironmentOperator.Get_Name();

            var lines_ForOutput = Instances.EnumerableOperator.From("Directory separators:\n")
                .Append_Many(Instances.EnumerableOperator.Empty<string>()
                    .Append($"'{directorySeparator_Windows}': windows")
                    .Append($"'{directorySeparator_NonWindows}': non-windows")
                    .Append_BlankLine()
                    .Append($"'{directorySeparator_Environment}': environment ({environmentName})")
                    .Append($"'{directorySeparator_Environment_Alternate}': environment-alternate")
                    .Append_BlankLine()
                    .Append($"'{directorySeparator_Standard}': standard")
                    .Entab()
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }
        
        /// <summary>
        /// A quick demonstrations of path part combination functionality.
        /// </summary>
        public async Task Combine()
        {
            /// Inputs.
            var pathParts = Instances.ArrayOperator.From(
                Instances.Paths_Roots.C_Drive,
                Instances.DirectoryNames.Directory01);

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var path = Instances.PathOperator.Combine(pathParts);

            var lines_ForOutput = Instances.EnumerableOperator.From(path)
                .Append("=>")
                .Append_Many(pathParts.Entab())
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }
    }
}
