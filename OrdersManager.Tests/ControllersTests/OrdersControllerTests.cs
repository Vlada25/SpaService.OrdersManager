using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrdersManager.API.Controllers;
using OrdersManager.Domain;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Tests.ControllersTests
{
    public class OrdersControllerTests
    {
        private static IMapper _mapper;

        public OrdersControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        private IEnumerable<Order> GetOrdersList()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8"),
                    ClientId = new Guid("83740e89-d586-4847-9833-c3d74d5288a7"),
                    ScheduleId = new Guid("4c38403b-56aa-4bb6-8b0f-8510f2f790c1")
                },
                new Order
                {
                    Id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303"),
                    ClientId = new Guid("696a2f05-004c-43aa-9e45-86d2f39671d4"),
                    ScheduleId = new Guid("6b68b6cb-2f51-40ea-a648-b690e6db6ef3")
                }
            };
        }

        [Fact]
        public void GetAll_SendRequest_ReturnEmptyList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            repositoryManager.Setup(r => r.OrdersRepository.GetAll(false))
                .Returns(new List<Order>());

            var controller = new OrdersController(repositoryManager.Object, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var orders = result.Value as IEnumerable<Order>;
            orders.Should().HaveCount(0);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnCompletedList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var fakeOrdersList = GetOrdersList();

            repositoryManager.Setup(r => r.OrdersRepository.GetAll(false))
                .Returns(fakeOrdersList);

            var controller = new OrdersController(repositoryManager.Object, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var orders = result.Value as IEnumerable<Order>;
            orders.Should().HaveSameCount(fakeOrdersList);
            orders.Should().BeEquivalentTo(fakeOrdersList);
        }

        [Fact]
        public void Get_SendRequest_ReturnModelById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var order = GetOrdersList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.OrdersRepository.GetById(id, false))
                .Returns(order);

            var controller = new OrdersController(repositoryManager.Object, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultOrder = result.Value as Order;

            Assert.Equal(order.Id, resultOrder.Id);
            Assert.Equal(order.ClientId, resultOrder.ClientId);
            Assert.Equal(order.ScheduleId, resultOrder.ScheduleId);
        }

        [Fact]
        public void Create_SendRequest_ReturnStatusCode201()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            Order order = new Order
            {
                ClientId = new Guid("734306c0-132c-4a4a-b2ab-069d5b7d44a6"),
                ScheduleId = new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf")
            };

            OrderForCreationDto orderForCreation = new OrderForCreationDto
            {
                ClientId = new Guid("734306c0-132c-4a4a-b2ab-069d5b7d44a6"),
                ScheduleId = new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf")
            };

            repositoryManager.Setup(r => r.OrdersRepository.Create(order));

            var controller = new OrdersController(repositoryManager.Object, _mapper);

            // Act
            var response = controller.Create(orderForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Delete_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var orders = GetOrdersList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.OrdersRepository.GetById(id, false))
                .Returns(orders);
            repositoryManager.Setup(r => r.OrdersRepository.Delete(orders));

            var controller = new OrdersController(repositoryManager.Object, null);

            // Act
            var response = controller.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Update_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var orders = GetOrdersList().ToList().Find(m => m.Id.Equals(id));
            var orderForUpdate = new OrderForUpdateDto
            {
                Id = id,
                ClientId = new Guid("734306c0-132c-4a4a-b2ab-069d5b7d44a6"),
                ScheduleId = new Guid("dd3511a8-4397-45e8-8188-ea572f9c6baf")
            };

            repositoryManager.Setup(r => r.OrdersRepository.GetById(id, true))
                .Returns(orders);

            var controller = new OrdersController(repositoryManager.Object, _mapper);

            // Act
            var response = controller.Update(orderForUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
