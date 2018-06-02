using System;
using System.Collections.Generic;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators.ModelValidators;

namespace MicroHermes.Vehicles.Core.Validators
{
    public class VehicleModelValidation : IVehicleModelValidation
    {
        private readonly IEnumerable<IVehicleModelValidator> _validators;

        public VehicleModelValidation(IServiceProvider serviceProvider)
        {
            //Not using Microsoft.Extensions.DependencyInjection as it is an extension method and not mockable with Moq
            _validators= serviceProvider.GetService(typeof(IEnumerable<IVehicleModelValidator>)) as List<IVehicleModelValidator>;
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