using System;
using BogusBuilder.Contributors;
using FluentAssertions;
using Xunit;

namespace BogusBuilder.Tests;

/// <summary>
/// Tests using the vanilla builder pattern
/// </summary>
public class SendSomeMessageUsingVanillaBuilderTests
{
  [Fact]
  public void ShouldNotThrowExceptionWhenContributorDTOIsPopulated()
  {
    var contributorDto = new ContributorDtoBuilderV1()
        .WithTestValues()
        .WithStatus(ContributorStatus.CoreTeam)
        .Build();
    var sut = new ContributorService();

    Action act = () => sut.SendSomeMessage(contributorDto);

    act.Should().NotThrow<Exception>();
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void ShouldThrowAnExceptionWhenDtoFailsValidation(int id)
  {
    var contributorDto = new ContributorDtoBuilderV1()
        .WithTestValues()
        .WithId(id)
        .WithStatus(ContributorStatus.CoreTeam)
        .Build();
    var sut = new ContributorService();

    Action act = () => sut.SendSomeMessage(contributorDto);

    act.Should().Throw<Exception>();
  }
}

/// <summary>
/// Uses the Bogus based builder pattern
/// </summary>
public class SendSomeMessageUsingBogusBuilder
{
  [Fact]
  public void ShouldNotThrowExceptionWhenContributorDTOIsPopulated()
  {
    var contributorDto = new ContributorDtoBuilderV2()
        .WithStatus(ContributorStatus.CoreTeam)
        .Build();
    var sut = new ContributorService();

    Action act = () => sut.SendSomeMessage(contributorDto);

    act.Should().NotThrow<Exception>();
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void ShouldThrowAnExceptionWhenDtoFailsValidation(int id)
  {
    var contributorDto = new ContributorDtoBuilderV2()
        .WithId(id)
        .WithStatus(ContributorStatus.CoreTeam)
        .Build();
    var sut = new ContributorService();

    Action act = () => sut.SendSomeMessage(contributorDto);

    act.Should().Throw<Exception>();
  }
}