using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalServices.Controllers;
using CommunalServices.Model;
using CommunalServices.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CommunalServices.Tests
{
    public class MeasuresControllerTests
    {
        #region Index

        [Fact]
        public async Task IndexReturnsAViewResultWithAListOfMeasures()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAllAsync<Measure>()).ReturnsAsync(await GetFakeMeasuresAsync());
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Measure>>(viewResult.Model);
            Assert.Equal(GetFakeMeasures().Count, model.Count());
        }

        #endregion

        #region Create

        [Fact]
        public async Task CreteMeasureReturnsRedirectAndCreteMeasure()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);
            var measure = new Measure { Name = "Гк" };

            // Act
            var result = await controller.Create(measure);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.CreateAsync(measure));
        }

        [Fact]
        public async Task CreteMeasureReturnsViewResultWithMeasureModel()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            Measure measure = new Measure();

            // Act
            var result = await controller.Create(measure);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(measure, viewResult?.Model);
        }

        #endregion

        #region Edit

        [Fact]
        public async Task EditReturnsBadRequestResultWhenIdIsNull()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Edit(null as int?);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task EditReturnsNotFoundResultWhenMeasureNotFound()
        {
            // Arrange
            int testMeasureId = 4;
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAsync<Measure>(testMeasureId))
                .ReturnsAsync(await GetFakeMeasureAsync(testMeasureId));
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Edit(testMeasureId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditReturnsViewResultWithMeasure()
        {
            // Arrange
            int testMeasureId = 1;
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAsync<Measure>(testMeasureId))
                .ReturnsAsync(await GetFakeMeasureAsync(testMeasureId));
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Edit(testMeasureId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Measure>(viewResult.Model);
            Assert.Equal("Гк", model.Name);
            Assert.Equal(testMeasureId, model.Id);
        }

        [Fact]
        public async Task EditMeasureReturnsRedirectAndEditMeasure()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);
            var measure = new Measure { Id = 1, Name = "Кв.м" };

            // Act
            var result = await controller.Edit(measure);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.EditAsync(measure));
        }

        [Fact]
        public async Task EditMeasureReturnsViewResultWithMeasureModel()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);
            controller.ModelState.AddModelError("Name", "Required");
            Measure measure = new Measure {Id = 1, Name = null};

            // Act
            var result = await controller.Edit(measure);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(measure, viewResult?.Model);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task DeleteReturnsBadRequestResultWhenIdIsNull()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Delete(null as int?);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteReturnsNotFoundResultWhenMeasureNotFound()
        {
            // Arrange
            int testMeasureId = 4;
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAsync<Measure>(testMeasureId))
                .ReturnsAsync(await GetFakeMeasureAsync(testMeasureId));
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Delete(testMeasureId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteReturnsViewResultWithMeasure()
        {
            // Arrange
            int testMeasureId = 1;
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAsync<Measure>(testMeasureId))
                .ReturnsAsync(await GetFakeMeasureAsync(testMeasureId));
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Delete(testMeasureId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Measure>(viewResult.Model);
            Assert.Equal("Гк", model.Name);
            Assert.Equal(testMeasureId, model.Id);
        }

        [Fact]
        public async Task DeleteReturnsBadRequestResultWhenModelIsNull()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);

            // Act
            var result = await controller.Delete(null as Measure);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteMeasureReturnsRedirectAndDeleteMeasure()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            var controller = new MeasuresController(mock.Object);
            var measure = new Measure { Id = 1 };

            // Act
            var result = await controller.Delete(measure);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.RemoveAsync(measure));
        }

        #endregion

        #region Private methods

        private List<Measure> GetFakeMeasures()
        {
            return new List<Measure>
            {
                new Measure() {Id = 1, Name = "Гк"},
                new Measure() {Id = 2, Name = "Куб.м"},
                new Measure() {Id = 3, Name = "КВт"}
            };
        }

        private async Task<List<Measure>> GetFakeMeasuresAsync()
        {
            return await Task<List<Measure>>.Factory.StartNew(GetFakeMeasures);
        }

        private async Task<Measure> GetFakeMeasureAsync(int id) =>
            (await GetFakeMeasuresAsync()).FirstOrDefault(m => m.Id == id);

        #endregion
    }
}
