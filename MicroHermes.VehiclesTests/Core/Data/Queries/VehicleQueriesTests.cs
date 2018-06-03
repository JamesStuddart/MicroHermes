using System.IO;
using System.Reflection;
using MicroHermes.Vehicles.Core.Data.Queries;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Should;
using Xunit;

namespace MicroHermes.VehiclesTests.Core.Data.Queries
{
    public class VehicleQueriesTests
    {
        private readonly IVehicleQueries _vehicleQueries;
        private readonly Mock<IHostingEnvironment> _hostingEnvironment;
        
        public VehicleQueriesTests()
        {
            _hostingEnvironment = new Mock<IHostingEnvironment>();
            _hostingEnvironment.Setup(x=>x.ContentRootPath).Returns(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _vehicleQueries = new VehicleQueries(_hostingEnvironment.Object);
        }

        [Fact]
        public void SDHP_GetVehicleByVin()
        {
            //Arrange
            var vin = "JM1CW2BLE0I106097";
            
            //Act
            var vehicles = _vehicleQueries.GetVehicleByVin(vin);
            
            //Assert
            vehicles.ShouldNotBeNull();
        }
        
        [Fact]
        public void Fail_GetVehicleByVin_Invalid_Vin()
        {
            //Arrange
            var vin = "RandomMadeUpString";
            
            //Act
            var vehicles = _vehicleQueries.GetVehicleByVin(vin);
            
            //Assert
            vehicles.ShouldBeNull();
        }
    }
}