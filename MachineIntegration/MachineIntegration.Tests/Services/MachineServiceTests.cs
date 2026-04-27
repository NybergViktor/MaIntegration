using System;
using System.Collections.Generic;
using System.Text;
using MachineIntegration.DTO;
using MachineIntegration.Models;
using MachineIntegration.Services;
using Microsoft.AspNetCore.Mvc;

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

        [Fact]
        public void GetActiveAlarms_ShouldReturnOnlyUnresolvedAlarms()
        {
            var service = new EventService();

            var dto1 = new AddMachineEventDTO
            {
                MachineId = "id1",
                Type = "Alarm",
                Message = "Test",
            };
            var dto2 = new AddMachineEventDTO
            {
                MachineId = "id2",
                Type = "Info",
                Message = "Test",
            };
            service.CreateMachineEvent(dto1);
            service.CreateMachineEvent(dto2);

            List<MachineEvent> foundEvents = service.GetActiveAlarms();

            foreach (var foundEvent in foundEvents)
            {
                Assert.True(!foundEvent.IsResolved && foundEvent.Type.Equals("Alarm"), $"IsResolved should be false, but was: {foundEvent.IsResolved} && Type should be 'Alarm', but was: {foundEvent.Type}");
            }
        }
    }
}
