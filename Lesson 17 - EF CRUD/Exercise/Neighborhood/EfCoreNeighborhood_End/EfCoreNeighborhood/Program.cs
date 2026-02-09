using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfCoreNeighborhood
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public char District { get; set; }
        public List<House> Houses { get; set; } = new();
    }
    public class House
    {
        public int Id { get; set; }
        public string Address { get; set; } = "";
        public string PostalCode { get; set; } = "";

        public int NeighborhoodId { get; set; }
        public Neighborhood? Neighborhood { get; set; }
    }
    public class ResidentialContext : DbContext
    {
        public DbSet<Neighborhood> Neighborhoods => Set<Neighborhood>();
        public DbSet<House> Houses => Set<House>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=residential.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(b =>
            {
                b.Property(h => h.Address).IsRequired().HasMaxLength(80);
                b.Property(h => h.PostalCode).IsRequired().HasMaxLength(6);
            });

            modelBuilder.Entity<Neighborhood>(b =>
            {
                b.Property(n => n.Name).IsRequired().HasMaxLength(100);
                b.Property(n => n.District).IsRequired();
                b.HasMany(n => n.Houses)
                 .WithOne(h => h.Neighborhood!)
                 .HasForeignKey(h => h.NeighborhoodId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ResidentialContext();
            context.Database.Migrate();

            CreateNeighborhood(context);
            Neighborhood neighborhood = GetOnlyNeighborhoodByName(context, "Garneau");
            Console.WriteLine("Created New Neighborhood");
            PrintNeighborhood(neighborhood);

            if (neighborhood != null)
                CreateHouses(context, neighborhood);

            Console.WriteLine("Added houses to Neighborhood");
            neighborhood = GetNeighborhoodAndHousesByName(context, "Garneau");
            PrintNeighborhood(neighborhood);

            UpdateDistrict(context, neighborhood, 'G');
            UpdateAddress(context, 2, "999 Pizza Place");
            neighborhood = GetNeighborhoodAndHousesByName(context, "Garneau");
            PrintNeighborhood(neighborhood);

            RemoveHouseById(context, 1);
            neighborhood = GetNeighborhoodAndHousesByName(context, "Garneau");
            PrintNeighborhood(neighborhood);

            RemoveNeighborhood(context, neighborhood);
            neighborhood = GetNeighborhoodAndHousesByName(context, "Garneau");
            PrintNeighborhood(neighborhood);
        }
        static void CreateNeighborhood(ResidentialContext context)
        {
            if (!context.Neighborhoods.Any())
            {
                var neighborhood = new Neighborhood
                {
                    Name = "Garneau",
                    District = 'P'
                };
                context.Neighborhoods.Add(neighborhood);
                context.SaveChanges();
            }
        }
        static void CreateHouses(ResidentialContext context, Neighborhood neighborhood)
        {
            if (!context.Houses.Any())
            {
                context.Houses.AddRange(
                    new House { Address = "123 Fake Street", PostalCode = "T5B2C7" , Neighborhood = neighborhood },
                    new House { Address = "555 Five Avenue", PostalCode = "T5C7Z1", Neighborhood = neighborhood },
                    new House { Address = "888 Ate Boulevard", PostalCode = "T5Q5V4", Neighborhood = neighborhood }
                );
                context.SaveChanges();
            }
        }
        static Neighborhood GetOnlyNeighborhoodByName(ResidentialContext context, string name)
        {
            if (context.Neighborhoods.Count(n => n.Name == name) > 0)
                return context.Neighborhoods.Single(n => n.Name == name);
            return null;
        }
        static Neighborhood GetNeighborhoodAndHousesByName(ResidentialContext context, string name)
        {
            if (context.Neighborhoods.Count(n => n.Name == name) > 0)
                return context.Neighborhoods.Include(n => n.Houses).Single(n => n.Name == name);
            return null;
        }
        static void PrintNeighborhood(Neighborhood neighborhood)
        {
            Console.WriteLine("-------------------");
            if (neighborhood != null)
            {
                Console.WriteLine($"Name: {neighborhood.Name}");
                Console.WriteLine($"District: {neighborhood.District}");
                Console.WriteLine($"Number of Houses: {neighborhood.Houses.Count}");
                foreach (House house in neighborhood.Houses)
                {
                    Console.WriteLine($"{house.Id}. {house.Address,-20} {house.PostalCode}");
                }
            }
            else
                Console.WriteLine("No such neighborhood");
            Console.WriteLine("-------------------");
        }
        static House GetHouseById(ResidentialContext context, int id)
        {
            if (context.Houses.Count(h => h.Id == id) > 0)
                return context.Houses.Single(h => h.Id == id);
            return null;
        }
        static void UpdateAddress(ResidentialContext context, int houseId, string newAddress)
        {
            House house = GetHouseById(context, houseId);
            if (house != null)
            {
                house.Address = newAddress;
                context.SaveChanges();
            }
        }
        static void UpdateDistrict(ResidentialContext context, Neighborhood neighborhood, char newDistrict)
        {
            neighborhood.District = newDistrict;
            context.SaveChanges();
        }
        static void RemoveHouseById(ResidentialContext context, int houseId)
        {
            House house = GetHouseById(context, houseId);
            if (house != null)
            {
                context.Houses.Remove(house);
                context.SaveChanges();
            }
        }
        static void RemoveNeighborhood(ResidentialContext context, Neighborhood neighborhood)
        {
            if (neighborhood != null)
            {
                context.Neighborhoods.Remove(neighborhood);
                context.SaveChanges();
            }
        }
    }
}
