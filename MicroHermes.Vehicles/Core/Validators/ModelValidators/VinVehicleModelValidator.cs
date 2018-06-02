using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Validators.ModelValidators
{
    public class VinVehicleModelValidator : IVehicleModelValidator
    {
        public new VehicleValidatorType GetType() => VehicleValidatorType.Vin;
        
        private const int VinLength = 17;

        public bool Validate(VehicleModel model)
        {
            var isValid = !string.IsNullOrEmpty(model.Vin) && model.Vin.Length == VinLength;
            
            //TODO: add some logging and insightful response msg back
            
            return isValid;
        }
    }
}