using Microsoft.EntityFrameworkCore;
using CarApi.Models;

namespace CarApi.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;

        }

        public void Seed()
        {
            _builder.Entity<User>(u =>
            {
                u.HasData(new User
                {
                    Id = new Guid("c2539447-ed58-4e0b-8175-5d7745210a2b"),
                    Name = ("Nathaniel Carballo"),
                    Email = ("nathaniel.carballo@gmail.com"),
                    Password = ("NCar10"),
                    DateOfBirth = new DateTime(1993, 10, 21),
                });

                u.HasData(new User
                {
                    Id = new Guid("34af3d8b-4b2a-4317-b254-3206c3a1124f"),
                    Name = ("John Cruz"),
                    Email = ("img_cruz@gmail.com"),
                    Password = ("LongCruz11"),
                    DateOfBirth = new DateTime(1995, 11, 10),
                });
            });
        
            _builder.Entity<Car>( c =>
            {
                c.HasData(new Car
                {
                    Id = new Guid ("8ac2e11d-d7b8-430d-ab32-2582c3b16a22"),
                    Make = ("Ford"),
                    Model = ("Mustang"),
                    Color = ("Red"),
                    Year = (1997),
                    Price = (1895),
                    UserId = new Guid("34af3d8b-4b2a-4317-b254-3206c3a1124f"),
                });
                c.HasData(new Car
                {
                    Id = new Guid ("f87db22f-bbf3-49d5-9d7a-a20a20f2b975"),
                    Make = ("Dodge"),
                    Model = ("Challenger"),
                    Color = ("Black"),
                    Year = (2018),
                    Price = (45000),
                    UserId = new Guid("c2539447-ed58-4e0b-8175-5d7745210a2b"),
                });
            });
        }
    }
}
