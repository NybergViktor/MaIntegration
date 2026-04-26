using System;
using System.Collections.Generic;
using System.Text;
using MachineIntegration.DTO;
using MachineIntegration.Services;

namespace MachineIntegration.Tests.Services
{
    public class MachineServiceTests
    {

        [Fact]
        public void GetMachineEvents_ShouldReturnCreatedEvents()
        {
            // Arrange
            var service = new EventService();

            service.CreateMachineEvent(new AddMachineEventDTO
            {
                MachineId = "PRESS-01",
                Type = "Alarm",
                Message = "Test"
            });

            // Act
            var events = service.GetMachineEvents();

            // Assert
            Assert.Single(events);
        }

        [Fact]
        public void CreateMachineEvent_WithEmptyMachineId_ShouldThrowException()
        {
            var service = new EventService();

            var dto = new AddMachineEventDTO
            {
                MachineId = "",
                Type = "Alarm",
                Message = "Test"
            };

            var exception = Assert.Throws<ArgumentException>(() => service.CreateMachineEvent(dto));

            Assert.Equal(exception.Message, "MachineId is required");
        }
    }
}
