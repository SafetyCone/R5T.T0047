using System;

using R5T.Magyar.T002;


namespace R5T.T0047.T002.X001
{
    public static class Instances
    {
        public static IExceptionGenerator ExceptionGenerator { get; } = Magyar.T002.ExceptionGenerator.Instance;
        public static IExceptionMessageGenerator ExceptionMessageGenerator { get; } = Magyar.T002.ExceptionMessageGenerator.Instance;
        public static INamedFilePathIndexEntryOperator NamedFilePathIndexEntryOperator { get; } = T0047.T002.NamedFilePathIndexEntryOperator.Instance;
    }
}
