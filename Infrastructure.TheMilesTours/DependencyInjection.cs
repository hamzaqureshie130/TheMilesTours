using Infrastructure.TheMilesTours.IRepository;
using Infrastructure.TheMilesTours.Persistence;
using Infrastructure.TheMilesTours.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //for connection string
            var connectionString = configuration.GetConnectionString("DefaultConnect") ??
                throw new InvalidOperationException("Connection string 'DefaultConnect' not found.");

            services.AddDbContext<ApplicationDbContext>(
                                              option => option.UseSqlServer(connectionString,
                                              b =>
                                              {
                                                  b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                                                  b.CommandTimeout(180);
                                              })
                                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Transient);
            //for identity
            //services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //                                                              .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //add Repository

            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourPlanRepository, TourPlanRepository>();
            services.AddScoped<ITourPackageRepository, TourPackageRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IDestinationGalleryRepository, DestinationGalleryRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarGalleryRepository, CarGalleryRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();




            return services;
        }
    }
}

