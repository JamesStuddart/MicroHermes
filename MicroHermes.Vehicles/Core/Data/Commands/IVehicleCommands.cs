using MicroHermes.Vehicles.Core.Entities;

namespace MicroHermes.Vehicles.Core.Data.Commands
{
    public interface IVehicleCommands
    {
        bool UpdateVehicle(VehicleEntity entity);
    }
}