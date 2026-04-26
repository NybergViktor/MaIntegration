using System;
using System.Collections.Generic;
using System.Text;
using MachineIntegration.DTO;
using MachineIntegration.Interfaces;
using MachineIntegration.Models;

namespace MachineIntegration.Services
{
    public class EventService : IMachineEventService
    {
        private List<MachineEvent> _events = new();

        public MachineEvent CreateMachineEvent(AddMachineEventDTO dto)
        {

            MachineEvent machineEvent = new MachineEvent();
            machineEvent.Message = dto.Message;
            machineEvent.Type = dto.Type;
            machineEvent.MachineId = dto.MachineId;
            if (string.IsNullOrEmpty(machineEvent.MachineId))
            {
                throw new ArgumentException("MachineId is required");
            }
            if (machineEvent.Type != "Info" && machineEvent.Type != "Warning" && machineEvent.Type != "Alarm")
            {
                throw new ArgumentException("Type is required, Type was invalid.");
            }
            if (string.IsNullOrEmpty(machineEvent.Message))
            {
                throw new ArgumentException("Message was null.");
            }

            _events.Add(machineEvent);

            return machineEvent;
        }

        public List<MachineEvent> GetMachineEvents()
        {
            return _events.ToList();
        }
    }
}
