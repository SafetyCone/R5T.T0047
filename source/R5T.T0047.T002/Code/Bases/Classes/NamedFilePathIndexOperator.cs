using System;


namespace R5T.T0047.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class NamedFilePathIndexOperator : INamedFilePathIndexOperator
    {
        #region Static
        
        public static NamedFilePathIndexOperator Instance { get; } = new();

        #endregion
    }
}