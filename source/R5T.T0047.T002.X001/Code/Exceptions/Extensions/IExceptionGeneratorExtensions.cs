using System;

using R5T.Magyar.T002;

using R5T.T0047.T001;

using Instances = R5T.T0047.T002.X001.Instances;


namespace System
{
    public static class IExceptionGeneratorExtensions
    {
        public static InvalidOperationException EntryAlreadyExists(this IExceptionGenerator _,
            NamedFilePathIndexEntry entry)
        {
            var message = Instances.ExceptionMessageGenerator.EntryAlreadyExists(entry);

            var output = new InvalidOperationException(message);
            return output;
        }
    }
}
