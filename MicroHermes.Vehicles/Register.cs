using MicroHermes.Core.Data.Queries;
using MicroHermes.Core.Logging;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Validators;
using MicroHermes.Vehicles.Core.Validators.ModelValidators;
using Microsoft.Extensions.DependencyInjection;

namespace MicroHermes.Vehicles
{
    public static class Register
    {
        public static void InitializeDependencies(this IServiceCollection services)
        {
            //scoped (per request)


            //transient (per use)
            services.AddTransient<IVehicleModelValidator, VinVehicleModelValidator>();
            services.AddTransient<IVehicleModelValidation, VehicleModelValidation>();

            //singleton (there can only be one)
            services.AddSingleton<ILogger, ConsoleLogger>();
            
            services.AddSingleton<IVehicleCommands, VehicleCommands>();
            services.AddSingleton<IVehicleQueries, VehicleQueries>();
            
            services.AddSingleton<IVehicleYearQueries, VehicleYearQueries>();
            services.AddSingleton<IVehicleMakeQueries, VehicleMakeQueries>();
            services.AddSingleton<IVehicleModelQueries, VehicleModelQueries>();
            services.AddSingleton<IVehicleTrimQueries, VehicleTrimQueries>();
            services.AddSingleton<IVehicleEngineTypeQueries, VehicleEngineTypeQueries>();
            services.AddSingleton<IVehicleTransmissionQueries, VehicleTransmissionQueries>();
            services.AddSingleton<IVehicleDriveTrainQueries, VehicleDriveTrainQueries>();
            services.AddSingleton<IVehicleBodyTypeQueries, VehicleBodyTypeQueries>();
            services.AddSingleton<IVehicleVehicleTypeQueries, VehicleVehicleTypeQueries>();
            services.AddSingleton<IVehicleInteriorColorQueries, VehicleInteriorColorQueries>();
            services.AddSingleton<IVehicleExteriorColorQueries, VehicleExteriorColorQueries>();
            
            services.AddSingleton<IVehicleEntityMapper, VehicleEntityMapper>();
            services.AddSingleton<IVehicleModelMapper, VehicleModelMapper>();
        }
    }
}
