using MicroHermes.Vehicles.Core.Entities;

namespace MicroHermes.Vehicles.Core.Data.Queries
{
    public interface IVehicleQueries
    {
        VehicleEntity GetVehicleByVin(string vin);
    }
}