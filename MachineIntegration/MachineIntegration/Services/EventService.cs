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

        public MachineEvent ResolveEvent(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Id can not be null.");

            MachineEvent foundEvent = new MachineEvent();
            foundEvent = _events.Find(m => m.Id == id);
            if (foundEvent != null)
            {
                foundEvent.IsResolved = true;
                return foundEvent;
            } else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Returns all event with type "Alarm" and IsResolved is false
        /// </summary>
        /// <returns></returns>
        public List<MachineEvent> GetActiveAlarms()
        {
            return _events.Where(n => n.Type == "Alarm" && !n.IsResolved).ToList();
        }
    }
}
