using System.Diagnostics.CodeAnalysis;
using Interview.Demo.Application.Interfaces.Services;

namespace Interview.Demo.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
