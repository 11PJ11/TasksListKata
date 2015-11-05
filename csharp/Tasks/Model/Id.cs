using System;

namespace Tasks.Model
{
    public class Id
    {
        public Id(object id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            _id = id;
        }

        public override string ToString()
        {
            return _id.ToString();
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
            return string.Equals(_id.ToString(), other._id.ToString());
        }

        private readonly object _id;

        private Id() { }
    }
}