using System.Collections.Generic;
using System.Linq;
using MicroHermes.Core;
using MicroHermes.Core.Data.Queries;
using MicroHermes.Core.Extensions;
using MicroHermes.Core.Models;
using MicroHermes.Vehicles.Core.Data;
using MicroHermes.Vehicles.Core.Data.Commands;
using MicroHermes.Vehicles.Core.Data.Queries;
using MicroHermes.Vehicles.Core.Mappers;
using MicroHermes.Vehicles.Core.Models;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MicroHermes.Vehicles.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicles")]
    public class GetVehiclesController : Controller
    {
        private readonly IVehicleCommands _vehicleCommands;
        private readonly IVehicleQueries _vehicleQueries;

        private readonly IVehicleEntityMapper _entityMapper;
        
        public GetVehiclesController(IVehicleCommands vehicleCommands, IVehicleQueries vehicleQueries, IVehicleEntityMapper entityMapper)
        {
            _vehicleCommands = vehicleCommands;
            _vehicleQueries = vehicleQueries;
            _entityMapper = entityMapper;
        }

        [HttpGet("{vin}"), ActionName("vehicle.get")]
        public IActionResult GetVehicle(string vin)
        {
            //TODO: add guard pattern here for this check
            if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
                return BadRequest(vin); 
            
            var entity = _vehicleQueries.GetVehicleByVin(vin);

            if (entity == null)
                return NotFound(vin);

            var model = _entityMapper.ToVehicleModel(entity);

            //TODO: replace this with an inteligent way of doing it - JS 29/05/218
            var apiUri = Request.GetBaseUri() + Request?.Path.Value;
            
            var links = new List<HateoasLink>
            {
                new HateoasLink("vehicle.update.full", apiUri, HttpVerbs.Put),
                new HateoasLink("vehicle.update.partial", apiUri, HttpVerbs.Patch),
            };
            
            var response = new HateoasResponseObject<VehicleModel>(model, links);
            
            return Ok(response);
        }
    }
}