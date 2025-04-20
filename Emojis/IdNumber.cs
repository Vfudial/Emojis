namespace Emojis
{
    public class IdNumber
    {
        private static int _thisId;
        public int Id { get; }
        public IdNumber()
        {
            Id = _thisId++;
        }
        public IdNumber(int id)
        {
            Id = id;
        }

        public IdNumber(IdNumber number)
        {
            Id = number.Id;
        }
        protected new bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is IdNumber number)
            {
                return Id == number.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}