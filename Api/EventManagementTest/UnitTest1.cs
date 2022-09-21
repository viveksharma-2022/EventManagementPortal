using AdminApi.Controllers;
using CommonDbLayer.CommonDbEntities;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementTest
{
    public class UnitTest1
    {
        private readonly AdminController _controller;
        private readonly Adminservicefake _adminservice;
        private readonly EventManagementServiceFakes _eventService;
        public UnitTest1()
        {
            _eventService = new EventManagementServiceFakes();
            _adminservice = new Adminservicefake();
            _controller = new AdminController(_adminservice, _eventService);

        }

        [Fact]
        public void Get_Whencalled_ReturnOkResult()
        {
            var okResult=_controller.GetAllEvents();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_Whencalled_ReturnAllEvents()
        {
            var okResult = _controller.GetAllEvents() as OkObjectResult;
            var item = Assert.IsType<List<Event>>(okResult.Value);
            Assert.Equal(1, item.Count);
            //Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void GetById_ExistingidPassed_ReturnsRightItem()
        {
            // Arrange
            var EventId = 100;

            // Act
            var okResult = _controller.GetEventById(EventId) as OkObjectResult;

            // Assert
            Assert.IsType<Event>(okResult.Value);
            Assert.Equal(EventId, (okResult.Value as Event).EventId);
        }
    }
}



