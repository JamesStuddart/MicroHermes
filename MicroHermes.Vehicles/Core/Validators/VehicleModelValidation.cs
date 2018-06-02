using System;
using System.Collections.Generic;
using MicroHermes.Vehicles.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MicroHermes.Vehicles.Core.Validators
{
    public class VehicleModelValidation : IVehicleModelValidation
    {
        private readonly IEnumerable<IVehicleModelValidation> _validators;
        
        public VehicleModelValidation(IServiceProvider serviceProvider)
        {
            _validators = serviceProvider.GetServices<IVehicleModelValidation>();
        }
        
        public bool Validate(VehicleModel model)
        {
            var isValid = true;
            
            foreach (var validator in _validators)
            {
                if (!validator.Validate(model))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}