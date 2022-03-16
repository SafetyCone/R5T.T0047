using System;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using R5T.T0047.T001;
using R5T.T0047.T002;


namespace System
{
    public static class INamedFilePathIndexOperatorExtensions
    {
        public static NamedFilePathIndex LoadFromJsonFile(this INamedFilePathIndexOperator _,
            string jsonFilePath)
        {
            var entriesArray = JsonFileHelper.LoadFromFile<NamedFilePathIndexEntry[]>(jsonFilePath);

            var output = _.From(entriesArray);
            return output;
        }

        public static void WriteToJsonFile(this INamedFilePathIndexOperator _,
            string jsonFilePath,
            NamedFilePathIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var entriesInOrder = index.Entries
                .OrderAlphabetically(xEntry => xEntry.Name)
                ;

            JsonFileHelper.WriteToFile(jsonFilePath, entriesInOrder, overwrite: overwrite);
        }

        public static void WriteToJsonFileWithoutAlphabetizationByName(this INamedFilePathIndexOperator _,
            string jsonFilePath,
            NamedFilePathIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            JsonFileHelper.WriteToFile(jsonFilePath, index.Entries, overwrite: overwrite);
        }
    }
}