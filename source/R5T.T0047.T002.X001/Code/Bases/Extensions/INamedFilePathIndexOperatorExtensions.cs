using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0047.T001;
using R5T.T0047.T002;

using Instances = R5T.T0047.T002.X001.Instances;


namespace System
{
    public static class INamedFilePathIndexOperatorExtensions
    {
        public static void AddEntryUnconstrained(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            NamedFilePathIndexEntry entry)
        {
            index.Entries.Add(entry);
        }

        public static void AddEntryIdempotent(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            NamedFilePathIndexEntry entry)
        {
            var wasFound = _.HasEntryFirstOrDefault(index, entry);
            if (!wasFound)
            {
                // Only if not found, add the entry.
                _.AddEntryUnconstrained(index, entry);
            }
        }

        public static void AddEntryNonIdempotent(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            NamedFilePathIndexEntry entry)
        {
            var wasFound = _.HasEntryFirstOrDefault(index, entry);
            if (wasFound)
            {
                throw Instances.ExceptionGenerator.EntryAlreadyExists(entry);
            }

            _.AddEntryUnconstrained(index, entry);
        }

        /// <summary>
        /// Selects <see cref="AddEntryIdempotent(INamedFilePathIndexOperator, NamedFilePathIndex, NamedFilePathIndexEntry)"/> as the default.
        /// </summary>
        public static void AddEntry(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            NamedFilePathIndexEntry entry)
        {
            _.AddEntryIdempotent(index, entry);
        }

        public static void AddEntry(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            string projectName,
            string projectFileName)
        {
            var entry = Instances.NamedFilePathIndexEntryOperator.From(
                projectName,
                projectFileName);

            _.AddEntry(index, entry);
        }

        public static void ClearEntries(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index)
        {
            index.Entries.Clear();
        }

        public static NamedFilePathIndex From(this INamedFilePathIndexOperator _,
            IEnumerable<NamedFilePathIndexEntry> entries)
        {
            var output = _.New();

            output.Entries.AddRange(entries);

            return output;
        }

        public static IEnumerable<string> GetAllNames(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index)
        {
            var output = index.Entries
                .Select(xEntry => xEntry.Name)
                ;

            return output;
        }

        public static WasFound<NamedFilePathIndexEntry> HasEntryFirstOrDefault(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            string projectName,
            string projectFilePath)
        {
            var entryOrDefault = index.Entries
                .Where(xEntry => Instances.NamedFilePathIndexEntryOperator.Equal(xEntry, projectName, projectFilePath))
                .FirstOrDefault(); // Use less-robust but speedier First().

            var output = WasFound.From(entryOrDefault);
            return output;
        }

        public static WasFound<NamedFilePathIndexEntry> HasEntryFirstOrDefault(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            NamedFilePathIndexEntry entry)
        {
            var entryOrDefault = index.Entries
                .Where(xEntry => Instances.NamedFilePathIndexEntryOperator.Equal(xEntry, entry))
                .FirstOrDefault(); // Use less-robust but perhaps speedier First().

            var output = WasFound.From(entryOrDefault);
            return output;
        }

        public static NamedFilePathIndex New(this INamedFilePathIndexOperator _)
        {
            var output = new NamedFilePathIndex();
            return output;
        }

        public static void ReplaceEntries(this INamedFilePathIndexOperator _,
            NamedFilePathIndex index,
            IEnumerable<NamedFilePathIndexEntry> entries)
        {
            _.ClearEntries(index);

            index.Entries.AddRange(entries);
        }
    }
}
