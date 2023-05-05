using API_Models;
using Microsoft.EntityFrameworkCore;


namespace Labb_4_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed persons
            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "555-1234", Links = new List<Link>() },
                new Person { PersonId = 2, FirstName = "Sam", LastName = "Andersson", PhoneNumber = "555-5678", Links = new List<Link>() }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { InterestId = 1, InterestName = "Social Media", InterestDescription = "Social Media Description", Links = new List<Link>() },
                new Interest { InterestId = 2, InterestName = "Music", InterestDescription = "Music Description", Links = new List<Link>() }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { LinkId = 1, InterestId = 1, PersonId = 1, LinkURL = "twitter.com", },
                new Link { LinkId = 2, InterestId = 1, PersonId = 1, LinkURL = "instagram.com" },
                new Link { LinkId = 3, InterestId = 2, PersonId = 2, LinkURL = "spotify.com" },
                new Link { LinkId = 4, InterestId = 2, PersonId = 2, LinkURL = "soundcloud.com" },
                new Link { LinkId = 5, InterestId = 2, PersonId = 1, LinkURL = "soundcloud.com" }
            );
        }
    }
}
