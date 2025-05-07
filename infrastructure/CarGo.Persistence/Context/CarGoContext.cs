using Cargo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGo.Persistence.Context
{
   public class CarGoContext : DbContext 

    {
        public CarGoContext(DbContextOptions<CarGoContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CarGodb;Username=postgres;Password=1234");

        }

        public DbSet<About> Abouts{ get; set; }
        public DbSet<Banner> Banners{ get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricing { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<FooterAddress> FooterAddresss { get; set; }
        public DbSet<Location> Locations{ get; set; }
        public DbSet<Pricing> Pricings{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<SocialMedia> Socialmedias{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }


    }
}
