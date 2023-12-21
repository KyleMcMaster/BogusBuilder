using System;
using FluentAssertions;
using Xunit;

namespace BogusBuilder.Tests;

public class SendSomeMessage
{
    [Fact]
    public void ShouldNotThrowExceptionWhenContributorDTOIsPopulated()
    {
        var contributorDto = new ContributorDtoBuilderV1()
            .WithLongestStreakEver(365)
            .Build();
        var sut = new ContributorService();

        Action act = () => sut.SendSomeMessage(contributorDto);

        act.Should().NotThrow<Exception>();
    }
}