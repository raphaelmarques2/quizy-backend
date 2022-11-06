namespace Quizy.Shared.DDD
{
    public class Id : IEquatable<Id> {
        public string Value { get; private set; }

        public Id(string? id = null) {
            if(String.IsNullOrEmpty(id))
            {
                Value = Guid.NewGuid().ToString();
            }
            else
            {
                Value = id;
            }
        }

        public bool Equals(Id? other)
        {
            if (other == null) return false;
            return Value == other.Value;
        }
    }

}