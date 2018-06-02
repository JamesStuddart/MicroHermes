using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Validators.ModelValidators
{
    public class VinVehicleModelValidator : IVehicleModelValidator
    {
        public new VehicleValidatorType GetType() => VehicleValidatorType.Vin;
        
        
        
        private const int VinLength = 17;

        public bool Validate(VehicleModel model)
        {
            var isValid = model.Vin.Length > VinLength;


            
            return isValid;
        }
    }
}