using Hp_Web_App.Shared.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Hp_Web_App.Tests.Functions;

[TestClass()]
public class HelperFunctionsTests
{
    private readonly Mock<IHelperFunctions> helperFunctionsMock = new Mock<IHelperFunctions>();

    [TestMethod()]
    public void ConvertPascalCaseToSpaced_InputIsNull_ReturnsEmptyString()
    {
        // Arrange
        string input = null;
        helperFunctionsMock.Setup(x => x.ConvertPascalCaseToSpaced(It.IsAny<string>())).Returns(string.Empty);
        var helperFunctions = helperFunctionsMock.Object;

        // Act
        var result = helperFunctions.ConvertPascalCaseToSpaced(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod()]
    public void ConvertPascalCaseToSpaced_InputIsEmpty_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        helperFunctionsMock.Setup(x => x.ConvertPascalCaseToSpaced(It.IsAny<string>())).Returns(string.Empty);
        var helperFunctions = helperFunctionsMock.Object;

        // Act
        var result = helperFunctions.ConvertPascalCaseToSpaced(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod()]
    public void ConvertPascalCaseToSpaced_ValidInput_ReturnsSpacedString()
    {
        // Arrange
        string input = "ThisIsAValidInput";
        helperFunctionsMock.Setup(x => x.ConvertPascalCaseToSpaced(It.IsAny<string>())).Returns("This Is A Valid Input");
        var helperFunctions = helperFunctionsMock.Object;

        // Act
        var result = helperFunctions.ConvertPascalCaseToSpaced(input);

        // Assert
        Assert.AreEqual("This Is A Valid Input", result);
    }

    [TestMethod]
    public void ConvertPascalCaseToSpaced_InputHasSingleUppercaseLetter_ReturnsSameString()
    {
        // Arrange
        string input = "A";
        var mock = new Mock<IHelperFunctions>();
        mock.Setup(x => x.ConvertPascalCaseToSpaced(It.IsAny<string>())).Returns("A");
        var helperFunctions = mock.Object;

        // Act
        var result = helperFunctions.ConvertPascalCaseToSpaced(input);

        // Assert
        Assert.AreEqual("A", result);
    }
}