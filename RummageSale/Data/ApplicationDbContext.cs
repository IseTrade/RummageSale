using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RummageSale.Models;

namespace RummageSale.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RummageUser> RummageUser { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<RummageSale.Models.Sale> Sale_1 { get; set; }
        public DbSet<RummageSale.Models.Category> Category_1 { get; set; }

    }
}
