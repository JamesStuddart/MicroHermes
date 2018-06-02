using System;
using System.Collections.Generic;
using MicroHermes.Vehicles.Core;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators;
using MicroHermes.Vehicles.Core.Validators.ModelValidators;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Validators
{
    public class VehicleModelValidationTests
    {
        private readonly IVehicleModelValidation _vehicleModelValidation;
        private readonly Mock<IServiceProvider> _serviceProvider;
        private readonly Mock<IVehicleModelValidator> _vehicleModelValidator;
        private readonly IEnumerable<IVehicleModelValidator> _validators;
        
        public VehicleModelValidationTests()
        {
            _serviceProvider = new Mock<IServiceProvider>();
            _vehicleModelValidator = new Mock<IVehicleModelValidator>();
            _validators = new List<IVehicleModelValidator>{_vehicleModelValidator.Object};
            
            _serviceProvider.Setup(x => x.GetService(typeof(IEnumerable<IVehicleModelValidator>))).Returns(_validators);
            _vehicleModelValidation = new VehicleModelValidation(_serviceProvider.Object);
        }
        
        private VehicleModel ValidVehicleModel => new VehicleModel { Vin = "JM1CW2BLE0I106097"};

        [Fact]
        public void SDHP_Validate()
        {
            //Arrange
            _vehicleModelValidator.Setup(x => x.Validate(It.IsAny<VehicleModel>())).Returns(true);
            _vehicleModelValidator.Setup(x => x.GetType()).Returns(VehicleValidatorType.Vin);

            //Act
            var result = _vehicleModelValidation.Validate(ValidVehicleModel);
            
            //Assert
            result.ShouldBeTrue();
        }
        
        [Fact]
        public void Fail_Validate()
        {
            //Arrange
            _vehicleModelValidator.Setup(x => x.Validate(It.IsAny<VehicleModel>())).Returns(false);
            _vehicleModelValidator.Setup(x => x.GetType()).Returns(VehicleValidatorType.Vin);

            //Act
            var result = _vehicleModelValidation.Validate(ValidVehicleModel);
            
            //Assert
            result.ShouldBeFalse();
        }
    }
}