namespace Backend.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }

    public class Representative
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Company { get; set; } = null!;

        public DateOnly Date { get; set; } 

        public string Status { get; set; } = null!;
        public string Verified { get; set; }
        public int Activity { get; set; }
        public int Balance { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public int RepresentativeId { get; set; }
        public Representative Representative { get; set; } = null!;
    }

    public class Forms
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly Date { get; set; } 
        public string Gender { get; set; } = null!;

        public int Age { get; set; }
        public string Country { get; set; } = null!;
        public string Skills { get; set; } = null!; 
    }
}
