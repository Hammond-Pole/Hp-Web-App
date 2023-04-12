using Hp_Web_App.Shared.AppServices;
using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Hp_Web_App.Tests.Services;

public class QuestionServiceTests
{


    public QuestionServiceTests()
    {
        
    }

    //[Fact]
    //public async Task AddQuestionStringValuesAsync_ShouldAddValuesToDatabase()
    //{
    //    // Arrange
    //    var questionStringValuesMock = new Mock<DbSet<QuestionStringValue>>();
    //    var contextMock = new Mock<IDbWebAppContext>();
    //    contextMock.Setup(x => x.QuestionStringValues).Returns(questionStringValuesMock.Object);
    //    var serviceMock = new Mock<IQuestionService>();

    //    var newQuestionStringValues = new List<QuestionStringValue>
    //    {
    //        new QuestionStringValue
    //        {
    //            Id = 1,
    //            DocumentId = 1,
    //            QuestionFieldID = 1,
    //            DateValueChanged = DateTime.Now,
    //            StringValue = "Test Value 1"
    //        },
    //        new QuestionStringValue
    //        {
    //            Id = 2,
    //            DocumentId = 2,
    //            QuestionFieldID = 2,
    //            DateValueChanged = DateTime.Now,
    //            StringValue = "Test Value 2"
    //        }
    //    };

    //    serviceMock.Setup(x => x.AddQuestionValuesAsync(It.IsAny<List<QuestionStringValue>>())).ReturnsAsync(newQuestionStringValues);
    //    var controller = new DbWebAppContext(serviceMock.Object);

    //    // Act
    //    var result = await service.AddQuestionValuesAsync(newQuestionStringValues);

    //    // Assert
    //    questionStringValuesMock.Verify(x => x.AddRange(newQuestionStringValues), Times.Once);
    //    _mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    //    Assert.Equal(newQuestionStringValues, result);
    //}
}
