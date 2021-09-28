using System;

using R5T.Magyar.T002;

using R5T.T0047.T001;

using Instances = R5T.T0047.T002.X001.Instances;


namespace System
{
    public static class IExceptionMessageGeneratorExtensions
    {
        public static string EntryAlreadyExists(this IExceptionMessageGenerator _,
            NamedFilePathIndexEntry entry)
        {
            var output = $"Entry already exists:\n{Instances.NamedFilePathIndexEntryOperator.GetDescription(entry)}";
            return output;
        }
    }
}
