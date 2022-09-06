namespace CRUD_src.Data;
using Microsoft.EntityFrameworkCore;

public class GuitarsContext : DbContext
{
    public DbSet<Guitar> Guitars { get; set; }
    public DbSet<StringsKit> StringsKits { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }

    public GuitarsContext()
    {
        Database.EnsureCreated();
    }

    public void Initialize()
    {
        if(StringsKits.Count() == 0)
        {
            StringsKits.AddRange(
                new StringsKit { 
                    Id = 1, 
                    AmountOfStrings = 6, 
                    Producer = "Yamaha" },                                 
                new StringsKit { 
                    Id = 2, 
                    AmountOfStrings = 7, 
                    Producer = "Gibson" },                                 
                new StringsKit { 
                    Id = 3, 
                    AmountOfStrings = 8, 
                    Producer = "Schecter" });
            SaveChanges();
        }

        if(Users.Count() == 0)
        {
            Users.AddRange(
                new User { 
                    Id = 1, 
                    Name = "James" 
                },
                new User { 
                    Id = 2, 
                    Name = "Paul" 
                });
            SaveChanges();
        }

        if(BankAccounts.Count() == 0)
        {
            BankAccounts.AddRange(
                new BankAccount { 
                    Id = 1, 
                    Balance = 100, 
                    Owner = Users.Where(u => u.Id == 1).First() 
                },
                new BankAccount { 
                    Id = 2, 
                    Balance = 300, 
                    Owner = Users.Where(u => u.Id == 2).First() });
            SaveChanges();
        }

        if(Guitars.Count() == 0)
        {
            Guitars.AddRange(
                new Guitar
                {
                    Id = 1,
                    StringsKit = StringsKits.Where(s => s.Id == 1).First(),
                    Productor = "Yamaha",
                    Model = "Revstar",
                    Material = "Chambered mahogany",
                    Buyers = new() { Users.Where(u => u.Id == 1).First()}
                },
                new Guitar
                {
                    Id = 2,
                    StringsKit = StringsKits.Where(s => s.Id == 3).First(),
                    Productor = "Fender",
                    Model = "Stratocaster",
                    Material = "Mahogany",
                    Buyers = new() { 
                        Users.Where(u => u.Id == 1).First(),
                        Users.Where(u => u.Id == 2).First()
                    }
                },
                new Guitar
                {
                    Id = 3,
                    StringsKit = StringsKits.Where(s => s.Id == 2).First(),
                    Productor = "Schecter",
                    Model = "Omen-8",
                    Material = "Basswood",
                    Buyers = new() { Users.Where(u => u.Id == 2).First() }
                });
            SaveChanges();
            
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=GuitarsDB.db");
    }
}