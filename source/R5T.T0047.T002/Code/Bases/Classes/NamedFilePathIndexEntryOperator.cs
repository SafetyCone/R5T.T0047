using System;


namespace R5T.T0047.T002
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class NamedFilePathIndexEntryOperator : INamedFilePathIndexEntryOperator
    {
        #region Static
        
        public static NamedFilePathIndexEntryOperator Instance { get; } = new();

        #endregion
    }
}