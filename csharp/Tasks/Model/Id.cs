namespace Tasks.Model
{
    public class Id
    {
        private readonly object _id;
        private Id() { }

        public Id(object id)
        {
            _id = id;
        }

        protected bool Equals(Id other)
        {
            return Equals(_id, other._id);
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
    }
}