using IceCreamParlour.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Models
{
    public class AddDBContext : DbContext
    {
        public AddDBContext(DbContextOptions<AddDBContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<IceCreamParlour.Models.Payments> Payments { get; set; } = default!;
       
    }
};

