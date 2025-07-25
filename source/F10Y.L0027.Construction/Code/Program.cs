using System;
using System.Threading.Tasks;


namespace F10Y.L0027.Construction
{
    class Program
    {
        //        static void Main()
        //        {
        //            var filePath = Instances.DirectoryPaths.Example_Rooted;

        //            Console.WriteLine(filePath);
        //        }
        //    }
        //}

        static async Task Main()
        {
            //await Program.Scripts_Path();

            await Program.Demonstrations_();
            //await Program.Demonstrations_PathOperator();
        }

        #region Demonstrations

        static async Task Demonstrations_()
        {
            await Demonstrations.Instance
                .Write_Examples_All()
                //.Write_DriveNames_All()
                ;
        }

        static async Task Demonstrations_PathOperator()
        {
            await PathOperatorDemonstrations.Instance
                //.Combine()
                //.Display_DirectorySeparators()
                //.Is_DirectoryIndicated()
                //.Is_DirectoryIndicated_Single()
                //.Is_Resolved()
                //.Is_RootIndicated()
                //.Is_RootIndicated_Single()
                .Is_Windows()
                //.Split()
                ;
        }

        #endregion

        #region Scripts

        static async Task Scripts_Path()
        {
            await PathScripts.Instance
                //.Combine_ProjectReferencePaths()
                .Resolve_UnresolvedPath()
                ;
        }

        #endregion
    }
}