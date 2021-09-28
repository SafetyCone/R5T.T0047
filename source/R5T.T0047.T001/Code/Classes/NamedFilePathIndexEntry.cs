using System;


namespace R5T.T0047.T001
{
    public sealed class NamedFilePathIndexEntry
    {
        #region Static

        public static bool operator ==(NamedFilePathIndexEntry lhs, NamedFilePathIndexEntry rhs)
        {
            var output = lhs is null
                ? rhs is null
                : lhs.Equals(rhs)
                ;

            return output;
        }

        public static bool operator !=(NamedFilePathIndexEntry lhs, NamedFilePathIndexEntry rhs)
        {
            var output = !(lhs == rhs);
            return output;
        }

        #endregion


        public string Name { get; set; }
        public string FilePath { get; set; }


        public bool Equals(NamedFilePathIndexEntry other)
        {
            // This cannot be null, so check the other.
            if (other is null)
            {
                return false;
            }

            // Now check property equality.
            var output = true
                && this.FilePath == other.FilePath
                && this.Name == other.Name
                ;

            return output;
        }

        public override bool Equals(object obj)
        {
            // Sealed reference type, so very simple.
            var objAsEntry = obj as NamedFilePathIndexEntry;

            var output = this.Equals(objAsEntry);
            return output;
        }

        public override int GetHashCode()
        {
            var output = HashCode.Combine(
                this.FilePath,
                this.Name);

            return output;
        }

        public override string ToString()
        {
            var representation = $"{this.Name}: {this.FilePath}";
            return representation;
        }
    }
}
