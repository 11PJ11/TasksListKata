using System;
using System.Text.RegularExpressions;

namespace Tasks.Model
{
    public class Id
    {
        public Id(string id)
        {
            Validate(id);
            
            _id = id;
        }

        public override string ToString()
        {
            return _id;
        }

        private static void Validate(string id)
        {
            MustNotBeNullOrEmpty(id);
            MustNotContainSpaces(id);
            MustNotContainSpecialCharacters(id);
        }

        private static void MustNotContainSpecialCharacters(string id)
        {
            var regex = new Regex(@"^[\w|\d]*$");
            if (!regex.IsMatch(id))
                throw new InvalidOperationException("id value can't contain special characters");
        }

        private static void MustNotContainSpaces(string id)
        {
            if (id.Contains(" "))
                throw new InvalidOperationException("id value can't contain spaces");
        }

        private static void MustNotBeNullOrEmpty(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Id) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        protected bool Equals(Id other)
        {
            return string.Equals(_id, other._id);
        }

        private readonly string _id;

        private Id() { }
    }
}