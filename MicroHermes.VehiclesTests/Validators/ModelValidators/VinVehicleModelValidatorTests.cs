using MicroHermes.Vehicles.Core;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators.ModelValidators;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Validators.ModelValidators
{
    public class VinVehicleModelValidatorTests
    {
        private readonly IVehicleModelValidator _vehicleModelValidator;

        public VinVehicleModelValidatorTests()
        {
            _vehicleModelValidator = new VinVehicleModelValidator();
        }

        private VehicleModel ValidVehicleModel => new VehicleModel { Vin = "JM1CW2BLE0I106097"};
        private VehicleModel InvalidVehicleModelNullVin => new VehicleModel { Vin = null};
        private VehicleModel InvalidVehicleModelEmptyVin => new VehicleModel { Vin = string.Empty};
        private VehicleModel InvalidVehicleModelShortVin => new VehicleModel { Vin = "J"};
        private VehicleModel InvalidVehicleModelLongVin => new VehicleModel { Vin = "JM1CW2BLE0I106097O7308741080892lASDSACA74"};
        
        [Fact]
        public void SDHP_Validate()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(ValidVehicleModel);
            
            //Assert
            result.ShouldBeTrue();
            _vehicleModelValidator.GetType().ShouldEqual(VehicleValidatorType.Vin);
        }
        
        [Fact]
        public void Fail_Validate_Vin_Null()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelNullVin);
            
            //Assert
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void Fail_Validate_Vin_Empty()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelEmptyVin);
            
            //Assert
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void Fail_Validate_Vin_Too_Short()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelShortVin);
            
            //Assert
            result.ShouldBeFalse();
        }
        
        [Fact]
        public void Fail_Validate_Vin_Too_Long()
        {
            //Arrange
            
            //Act
            var result = _vehicleModelValidator.Validate(InvalidVehicleModelLongVin);
            
            //Assert
            result.ShouldBeFalse();
        }
    }
}