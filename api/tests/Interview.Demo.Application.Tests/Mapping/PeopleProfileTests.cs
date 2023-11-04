using AutoMapper;
using Interview.Demo.Application.Mapping;
using Xunit;

namespace Interview.Demo.Application.Tests.Mapping;

public class PeopleProfileTests
{
    [Fact]
    public void VerifyConfiguration()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<PeopleProfile>());

        configuration.AssertConfigurationIsValid();
    }
}
