namespace RaceResult
{
    public class Driver
    {
        public string Number { get; }

        public string Name { get; }

        public Driver(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Driver other))
                return false;

            return Number == other.Number; 
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
