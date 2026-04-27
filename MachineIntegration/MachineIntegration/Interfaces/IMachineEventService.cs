using System;
using System.Collections.Generic;
using System.Text;
using MachineIntegration.DTO;
using MachineIntegration.Models;

namespace MachineIntegration.Interfaces
{
    public interface IMachineEventService
    {
        public MachineEvent CreateMachineEvent(AddMachineEventDTO dto);
        public List<MachineEvent> GetMachineEvents();
        public MachineEvent ResolveEvent(Guid id);
        public List<MachineEvent> GetActiveAlarms();

        /*
         * 
            GetAll(...)
            GetActiveAlarms(...)
            Resolve(...)
         * 
        */
    }
}
