using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Mappers
{
    public interface IVehicleEntityMapper
    {
        VehicleModel ToVehicleModel(VehicleEntity entity);
    }
}