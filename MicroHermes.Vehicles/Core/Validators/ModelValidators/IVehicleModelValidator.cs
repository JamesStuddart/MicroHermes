using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Validators.ModelValidators
{
    public interface IVehicleModelValidator
    {
        VehicleValidatorType GetType();
        bool Validate(VehicleModel model);
    }
}