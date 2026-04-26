using System;
using System.Collections.Generic;
using System.Text;

namespace MachineIntegration.Models
{
    public class MachineEvent
    {
        public Guid Id { get; set; }
        public string MachineId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Info, Warning, Alarm
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public bool IsResolved { get; set; }

        public MachineEvent()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
            IsResolved = false;
        }
    }
}
