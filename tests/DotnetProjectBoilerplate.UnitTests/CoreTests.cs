using System;
using DotnetProjectBoilerplate.Application.Apps;

namespace DotnetProjectBoilerplate.UnitTests;

public class CoreTests
{
    private readonly string _appName = "TestCore";
    private readonly string _appPath = Directory.GetCurrentDirectory() + "/test-core";

    [Fact]
    public void CreateCoreProject_ShouldBeOk()
    {
        if (Directory.Exists(_appPath))
            Directory.Delete(_appPath, true);

        // Arrange
        var appService = new DddAppCreatorService();
        var app = appService.CreateApp(_appName, _appPath);

        // Act
        foreach (var project in app.Projects)
        {
            project.Generate();
        }

        // Assert
        foreach (var project in app.Projects)
        {
            var isExist = Directory.Exists(project.ApplicationPath);
            Assert.True(isExist == true);
        }
    }
}
