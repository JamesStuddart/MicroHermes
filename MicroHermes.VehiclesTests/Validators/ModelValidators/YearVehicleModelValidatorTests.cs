using System;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators.ModelValidators;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Validators.ModelValidators
{
    public class YearVehicleModelValidatorTests
    {
        private readonly IVehicleModelValidator _vehicleModelValidator;

        public YearVehicleModelValidatorTests()
        {
            _vehicleModelValidator = new YearVehicleModelValidator();
        }

        private VehicleModel ValidVehicleModel => new VehicleModel { Year = 2018};
        private VehicleModel InvalidVehicleModelZeroYear => new VehicleModel { Year = 0};
        private VehicleModel InvalidVehicleModelNegativeYear => new VehicleModel { Year = -2018};
        private VehicleModel InvalidVehicleModelFutureYear => new VehicleModel { Year = DateTime.UtcNow.Year + 10};
        
        [Fact]
        public void SDHP_Validate()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(ValidVehicleModel);
            
            //Assert
            result.ShouldBeTrue();
        }
        
        [Fact]
        public void Fail_Validate_Year_Zero()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelZeroYear);
            
            //Assert
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void Fail_Validate_Year_Negative()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelNegativeYear);
            
            //Assert
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void Fail_Validate_Vin_Year_Future()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelFutureYear);
            
            //Assert
            result.ShouldBeFalse();
        }
    }
}