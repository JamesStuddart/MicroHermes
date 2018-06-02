using System;
using MicroHermes.Vehicles.Core.Models;

namespace MicroHermes.Vehicles.Core.Validators.ModelValidators
{
    public class YearVehicleModelValidator : IVehicleModelValidator
    {
        public new VehicleValidatorType GetType() => VehicleValidatorType.Year;
        
        public bool Validate(VehicleModel model)
        {
            var isValid = model.Year < 0 && model.Year > DateTime.UtcNow.Year;
            
            //TODO: add some logging and insightful response msg back
            
            return isValid;
        }
    }
}