namespace RandomUserAPI.Models
{
    public class RandomUserResponse
    {
        public List<RandomUser>? Results { get; set; }
    }

    public class RandomUser
    {
        public Name? Name { get; set; }
        public string? Email { get; set; }
        public Dob? Dob { get; set; }
        public string? Phone { get; set; }
        public Location? Location { get; set; }
        public Picture? Picture { get; set; }
    }

    public class Name { public string? First { get; set; } public string? Last { get; set; } }
    public class Dob { public string? Date { get; set; } }
    public class Location
    {
        public Street? Street { get; set; }
        public string? City { get; set; }
    }
    public class Street { public int Number { get; set; } public string? Name { get; set; } }
    public class Picture { public string? Large { get; set; } }
}

