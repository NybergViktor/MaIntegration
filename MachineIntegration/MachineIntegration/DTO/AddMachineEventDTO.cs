using System;
using System.Collections.Generic;
using System.Text;

namespace MachineIntegration.DTO
{
    public class AddMachineEventDTO
    {
        public string MachineId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
