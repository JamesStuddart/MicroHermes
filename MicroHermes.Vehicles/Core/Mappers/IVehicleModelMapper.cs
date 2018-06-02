using MicroHermes.Vehicles.Core.Entities;
using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Mappers
{
    public interface IVehicleModelMapper
    {
        void UpdateVehicleEntityFromModel(VehicleEntity entity, VehicleModel model, bool partialUpdate = false);
    }
}