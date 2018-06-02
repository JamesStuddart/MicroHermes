using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Validators
{
    public interface IVehicleModelValidation
    {
        bool Validate(VehicleModel model);
    }
}