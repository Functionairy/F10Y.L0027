using System;

using F10Y.T0006;


namespace F10Y.L0027.Construction
{
    [DemonstrationsMarker]
    public partial interface IPathOperatorDemonstrations :
        Q000.IPathOperatorDemonstrations
    {
        #region Infrastructure

        string Q000.IPathOperatorDemonstrations.Output_TextFilePath =>
            Instances.FilePaths.Output_TextFilePath;

        void Q000.IPathOperatorDemonstrations.Open(params string[] filePaths)
            => Instances.NotepadPlusPlusOperator.Open(filePaths);

        #endregion
    }
}
