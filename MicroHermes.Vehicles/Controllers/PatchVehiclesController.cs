﻿using System.Collections.Generic;
using MicroHermes.Core;
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
    public class PatchVehiclesController : Controller
    {
        private readonly IVehicleCommands _vehicleCommands;
        private readonly IVehicleQueries _vehicleQueries;
        private readonly IVehicleModelValidation _vehicleModelValidation;
        private readonly IVehicleModelMapper _vehicleModelMapper;
        
        public PatchVehiclesController(IVehicleCommands vehicleCommands, IVehicleQueries vehicleQueries, IVehicleEntityMapper entityMapper, IVehicleModelValidation vehicleModelValidation, IVehicleModelMapper vehicleModelMapper)
        {
            _vehicleCommands = vehicleCommands;
            _vehicleQueries = vehicleQueries;
            _vehicleModelValidation = vehicleModelValidation;
            _vehicleModelMapper = vehicleModelMapper;
        }

        [HttpPatch("{vin}"), ActionName("vehicle.update.partial")]
        public IActionResult PartialUpdateVehicle([FromRoute] string vin, [FromBody] VehicleModel model)
        {
            //TODO: add guard pattern here for this check
            if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
                return BadRequest(vin); 
            
            //TODO: replace with Guard
            if (model == null)
                return NoContent();
            
            if (!_vehicleModelValidation.Validate(model))
                return BadRequest();

            var entity = _vehicleQueries.GetVehicleByVin(model.Vin);
            
            _vehicleModelMapper.UpdateVehicleEntityFromModel(entity,model,true);
            
            var updated = _vehicleCommands.UpdateVehicle(entity);

            if (!updated)
                return BadRequest(); 
            
            //TODO: replace this with an inteligent way of doing it - JS 29/05/218
            var apiUri = Request.GetBaseUri() + Request?.Path.Value;
            
            var links = new List<HateoasLink>
            {
                new HateoasLink("vehicle.update.full", $"{apiUri}", HttpVerbs.Put),
                new HateoasLink("vehicle.get", $"{apiUri}", HttpVerbs.Get),
            };

            var response = new HateoasResponseObject<VehicleModel>(model, links);

            return Ok(response);
        }
    }
}