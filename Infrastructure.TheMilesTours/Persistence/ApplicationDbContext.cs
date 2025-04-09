using DomainLayer.TheMilesTours.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Tour> Tour { get; set; }
       
        public DbSet<Gallery> Gallery { get; set; }
     
        public DbSet<TourPackage> TourPackage { get; set; }
        public DbSet<TourPlan> TourPlan { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<DestinationGallery> DestinationGallery { get; set; }
    }
}
