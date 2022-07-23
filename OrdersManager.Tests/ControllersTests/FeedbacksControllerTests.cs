using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrdersManager.API.Controllers;
using OrdersManager.Domain;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OrdersManager.DTO.Feedback;

namespace OrdersManager.Tests.ControllersTests
{
    public class FeedbacksControllerTests
    {
        private static IMapper _mapper;

        public FeedbacksControllerTests()
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

        private IEnumerable<Feedback> GetFeedbacksList()
        {
            return new List<Feedback>
            {
                new Feedback
                {
                    Id = new Guid("d53237e3-ecd7-4cba-a920-d5fdba75f4c8"),
                    Comment = "Good",
                    Mark = 4,
                    OrderId = new Guid("4c38403b-56aa-4bb6-8b0f-8510f2f790c1")
                },
                new Feedback
                {
                    Id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303"),
                    Comment = "Perfect job!",
                    Mark = 5,
                    OrderId = new Guid("6b68b6cb-2f51-40ea-a648-b690e6db6ef3")
                }
            };
        }

        [Fact]
        public void GetAll_SendRequest_ReturnEmptyList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            repositoryManager.Setup(r => r.FeedbacksRepository.GetAll(false))
                .Returns(new List<Feedback>());

            var controller = new FeedbacksController(repositoryManager.Object, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var feedbacks = result.Value as IEnumerable<Feedback>;
            feedbacks.Should().HaveCount(0);
        }

        [Fact]
        public void GetAll_SendRequest_ReturnCompletedList()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var fakeFeedbacksList = GetFeedbacksList();

            repositoryManager.Setup(r => r.FeedbacksRepository.GetAll(false))
                .Returns(fakeFeedbacksList);

            var controller = new FeedbacksController(repositoryManager.Object, null);

            // Act
            var response = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var feedbacks = result.Value as IEnumerable<Feedback>;
            feedbacks.Should().HaveSameCount(fakeFeedbacksList);
            feedbacks.Should().BeEquivalentTo(fakeFeedbacksList);
        }

        [Fact]
        public void Get_SendRequest_ReturnModelById()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();
            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var feedback = GetFeedbacksList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.FeedbacksRepository.GetById(id, false))
                .Returns(feedback);

            var controller = new FeedbacksController(repositoryManager.Object, null);

            // Act
            var response = controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);

            var resultFeedback = result.Value as Feedback;

            Assert.Equal(feedback.Id, resultFeedback.Id);
            Assert.Equal(feedback.Comment, resultFeedback.Comment);
            Assert.Equal(feedback.Mark, resultFeedback.Mark);
            Assert.Equal(feedback.OrderId, resultFeedback.OrderId);
        }

        [Fact]
        public void Create_SendRequest_ReturnStatusCode201()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            Feedback feedback = new Feedback
            {
                Comment = "Bad",
                Mark = 2,
                OrderId = new Guid("734306c0-132c-4a4a-b2ab-069d5b7d44a6")
            };

            FeedbackForCreationDto feedbackForCreation = new FeedbackForCreationDto
            {
                Comment = "Bad",
                Mark = 2,
                OrderId = new Guid("734306c0-132c-4a4a-b2ab-069d5b7d44a6")
            };

            repositoryManager.Setup(r => r.FeedbacksRepository.Create(feedback));

            var controller = new FeedbacksController(repositoryManager.Object, _mapper);

            // Act
            var response = controller.Create(feedbackForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Delete_SendRequest_ReturnStatusCode200()
        {
            // Arrange
            var repositoryManager = new Mock<IRepositoryManager>();

            var id = new Guid("b1525dab-732b-48b1-9146-96382a7e5303");
            var feedbacks = GetFeedbacksList().ToList().Find(m => m.Id.Equals(id));

            repositoryManager.Setup(r => r.FeedbacksRepository.GetById(id, false))
                .Returns(feedbacks);
            repositoryManager.Setup(r => r.FeedbacksRepository.Delete(feedbacks));

            var controller = new FeedbacksController(repositoryManager.Object, null);

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
            var feedbacks = GetFeedbacksList().ToList().Find(m => m.Id.Equals(id));
            var feedbackForUpdate = new FeedbackForUpdateDto
            {
                Id = id,
                Comment = "VERY BAD!!!",
                Mark = 1
            };

            repositoryManager.Setup(r => r.FeedbacksRepository.GetById(id, true))
                .Returns(feedbacks);

            var controller = new FeedbacksController(repositoryManager.Object, _mapper);

            // Act
            var response = controller.Update(feedbackForUpdate);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
