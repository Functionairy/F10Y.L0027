using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0027.L000
{
    [FunctionsMarker]
    public partial interface IPathOperator :
        L0000.IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0000.IPathOperator _L0000 => L0000.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
