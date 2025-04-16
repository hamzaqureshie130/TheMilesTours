
using ApplicationLayer.TheMilesTours.IService;
using ApplicationLayer.TheMilesTours.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourPlanService, TourPlanService>();
            services.AddScoped<ITourPackageService, TourPackageService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IDestinationGalleryService, DestinationGalleryService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarGalleryService, CarGalleryService>();
            services.AddScoped<IReviewsService, ReviewService>();
            return services;
            //dsd
        }
    }
}
