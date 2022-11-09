using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioDistribuicaoDosLucros.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.Controllers;
public class HealthControllerTest
{
    [Fact]
    public void HealthTest()
    {
        var controller = new HealthController();
        controller.Get().Should().BeOfType<OkObjectResult>();
    }
}