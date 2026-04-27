using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MachineIntegration.DTO;
using MachineIntegration.Interfaces;
using MachineIntegration.Models;
using MachineIntegration.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MachineIntegration.Controllers
{


    [ApiController]
    [Route("/api/event")]
    public class EventController : ControllerBase
    {
        private readonly IMachineEventService _service;

        public EventController(IMachineEventService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<MachineEvent> CreateMachineEvent(AddMachineEventDTO dto)
        {
            return Ok(_service.CreateMachineEvent(dto));
        }

        [HttpGet]
        public ActionResult<List<MachineEvent>> GetMachineEvents()
        {
            return Ok(_service.GetMachineEvents());
        }

        [HttpPut]
        [Route("{id}/resolve")]
        public ActionResult<MachineEvent> ResolveEvent(Guid id)
        {
            try
            {
                return Ok(_service.ResolveEvent(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/active-alarms")]
        public ActionResult<List<MachineEvent>> GetActiveAlarms()
        {
            return Ok(_service.GetActiveAlarms());
        }
    }


}
