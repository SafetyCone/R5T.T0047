using System;

using R5T.T0047.T001;
using R5T.T0047.T002;


namespace System
{
    public static class INamedFilePathIndexEntryOperatorExtensions
    {
        public static bool Equal(this INamedFilePathIndexEntryOperator _,
            NamedFilePathIndexEntry a,
            NamedFilePathIndexEntry b)
        {
            var output = a == b;
            return output;
        }

        public static bool Equal(this INamedFilePathIndexEntryOperator _,
            NamedFilePathIndexEntry a,
            string name,
            string filePath)
        {
            var output = a is not null
                && a.FilePath == filePath
                && a.Name == name
                ;

            return output;
        }

        public static NamedFilePathIndexEntry From(this INamedFilePathIndexEntryOperator _,
            string name,
            string filePath)
        {
            var output = new NamedFilePathIndexEntry
            {
                FilePath = filePath,
                Name = name
            };

            return output;
        }

        public static string GetDescription(this INamedFilePathIndexEntryOperator _,
            NamedFilePathIndexEntry entry)
        {
            var output = entry.ToString();
            return output;
        }

        public static bool HasFilePath(this INamedFilePathIndexEntryOperator _,
            NamedFilePathIndexEntry entry,
            string filePath)
        {
            var output = entry.FilePath == filePath;
            return output;
        }

        public static bool HasName(this INamedFilePathIndexEntryOperator _,
            NamedFilePathIndexEntry entry,
            string name)
        {
            var output = entry.Name == name;
            return output;
        }

        public static NamedFilePathIndexEntry New(this INamedFilePathIndexEntryOperator _)
        {
            var output = new NamedFilePathIndexEntry();
            return output;
        }
    }
}