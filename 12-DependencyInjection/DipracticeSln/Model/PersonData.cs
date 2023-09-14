namespace Model
{
    public class PersonData
    {
        public string? Name { get; set; }
        public Guid Ssn { get; set; }
        public PersonData(string? name) 
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Name:  {Name}, SSN:    ( {Ssn} )";
        }
    }
}