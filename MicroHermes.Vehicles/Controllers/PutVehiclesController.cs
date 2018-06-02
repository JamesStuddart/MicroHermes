using System.Collections.Generic;
using MicroHermes.Core;
using MicroHermes.Core.Data.Queries;
using MicroHermes.Core.Extensions;
using MicroHermes.Core.Models;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using MicroHermes.Vehicles.Core.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MicroHermes.Vehicles.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicles")]
    public class PutVehiclesController : Controller
    {
        private readonly IVehicleCommands _vehicleCommands;
        private readonly IVehicleQueries _vehicleQueries;
        private readonly IVehicleModelValidation _vehicleModelValidation;
        private readonly IVehicleModelMapper _vehicleModelMapper;
        
        public PutVehiclesController(IVehicleCommands vehicleCommands, IVehicleQueries vehicleQueries, IVehicleEntityMapper entityMapper, IVehicleModelValidation vehicleModelValidation, IVehicleModelMapper vehicleModelMapper)
        {
            _vehicleCommands = vehicleCommands;
            _vehicleQueries = vehicleQueries;
            _vehicleModelValidation = vehicleModelValidation;
            _vehicleModelMapper = vehicleModelMapper;
        }

        [HttpPut("{vin}"), ActionName("vehicle.update.full")]
        public IActionResult UpdateVehicle([FromRoute] string vin, [FromBody] VehicleModel model)
        {
            //TODO: replace with Guard
            if (model == null)
                return NoContent();
            
            if (_vehicleModelValidation.Validate(model))
                return BadRequest();

            var entity = _vehicleQueries.GetVehicleByVin(model.Vin);

            _vehicleModelMapper.UpdateVehicleEntityFromModel(entity,model);
            
            var updated = _vehicleCommands.UpdateVehicle(entity);

            if (!updated)
                return BadRequest(); 

            //TODO: replace this with an inteligent way of doing it - JS 29/05/218
            var apiBaseUri = Request.GetBaseUri();
            var modelBaseUri = Request.Path.Value.Replace(vin, model.Vin);
            
            var links = new List<HateoasLink>
            {
                new HateoasLink("vehicle.update.partial", $"{apiBaseUri}{modelBaseUri}", HttpVerbs.Patch),
                new HateoasLink("vehicle.get", $"{apiBaseUri}{modelBaseUri}", HttpVerbs.Get),

            };
            
            var response = new HateoasResponseObject<VehicleModel>(model, links);

            return Ok(response);
        }
    }
}