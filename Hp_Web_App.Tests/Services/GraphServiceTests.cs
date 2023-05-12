using Hp_Web_App.Shared.AppServices.Graph;
using Hp_Web_App.Shared.ClientFactories;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Graph;
using Microsoft.Graph.Users.Item.SendMail;

namespace Hp_Web_App.Tests.Services;

[TestClass]
public class GraphServiceTests
{
    [TestMethod]
    public async Task SendRegistrationEmail_ShouldSendMail_WhenValidDetailsArePassed()
    {
        // Arrange
        var email = "test@example.com";
        var name = "John Doe";
        var graphClientMock = new Mock<GraphServiceClient>();
        var graphClientFactoryMock = new Mock<IGraphClientFactory>();

        var configurationSectionMock = new Mock<IConfigurationSection>();
        configurationSectionMock.Setup(x => x.Value).Returns(It.IsAny<string>());

        var configurationMock = new Mock<IConfiguration>();
        configurationMock.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionMock.Object);

        graphClientFactoryMock
            .Setup(x => x.CreateClient(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(graphClientMock.Object);

        var graphService = new GraphService(configurationMock.Object, graphClientFactoryMock.Object);

        // Act
        await graphService.SendRegistrationEmail(email, name);

        // Assert
        graphClientFactoryMock.Verify(x => x.CreateClient(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()), Times.Once());

        graphClientMock.Verify(x => x.Users["noreply@hammondpole.co.za"]
            .SendMail.PostAsync(), Times.Once());

        // No exceptions should be thrown if the code reaches this point.
        Assert.IsTrue(true);
    }
}