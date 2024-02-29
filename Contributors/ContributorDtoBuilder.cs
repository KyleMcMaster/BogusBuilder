using Bogus;
using System;

// This usuallly lives in a test utilities project
namespace BogusBuilder.Contributors;

/// <summary>
/// Builder for a <see cref="ContributorDTO"/>. This is a simple builder that uses the constructor of the DTO.
/// Pattern taken from https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
/// </summary>
public class ContributorDtoBuilderV1
{
  private int _id;
  private string _email;
  private string _firstName;
  private string _lastName;
  private int _followers;
  private int _following;
  private int _stars;
  private string _status;
  private DateTimeOffset? _createdOn;
  private DateTimeOffset? _modifiedOn;
  private int? _contributionCount;
  private int? _numberOfDaysInStreak;
  private int? _longestStreakEver;
  private int? _mostContributionsInOneDay;

  public ContributorDtoBuilderV1 WithTestValues()
  {
    _id = 1;
    _email = "test@email.com";
    _firstName = "Test";
    _lastName = "User";
    _followers = 1;
    _following = 1;
    _stars = 1;
    _status = ContributorStatus.NotSet.Name;
    _createdOn = DateTimeOffset.UtcNow;
    _modifiedOn = DateTimeOffset.UtcNow;
    _contributionCount = 1;
    _numberOfDaysInStreak = 1;
    _longestStreakEver = 1;
    _mostContributionsInOneDay = 1;
    return this;
  }

  public ContributorDtoBuilderV1 WithId(int id)
  {
    _id = id;
    return this;
  }

  public ContributorDtoBuilderV1 WithStatus(ContributorStatus status)
  {
    _status = status.Name;
    return this;
  }

  // ...other "With" methods excluded

  public ContributorDTO Build()
  {
    return new(
      _id,
      _email,
      _firstName,
      _lastName,
      _followers,
      _following,
      _stars,
      _status,
      _createdOn,
      _modifiedOn,
      _contributionCount,
      _numberOfDaysInStreak,
      _longestStreakEver,
      _mostContributionsInOneDay);
  }
}

/// <summary>
/// Alternative builder for a <see cref="ContributorDTO"/>. This is a builder that uses a class that inherits from <see cref="Faker{T}"/>.
/// </summary>
public class ContributorDtoBuilderV2
{
  private int? _id;
  private ContributorStatus? _status;

  public ContributorDtoBuilderV2 WithId(int id)
  {
    _id = id;
    return this;
  }

  public ContributorDtoBuilderV2 WithStatus(ContributorStatus status)
  {
    _status = status;
    return this;
  }

  public ContributorDTO Build()
  {
    // If you have a Faker class you can use it here
    // _id ??= 1; // default to 1 if not provided
    //var contributor = new ContributorDTOFaker(_status)
    //    .Generate();

    // Or you can configure and use a local Faker instance here
    var faker = new Faker<ContributorDTO>()
      .CustomInstantiator(f => new ContributorDTO(
        Id: _id ?? f.UniqueIndex,
        Email: f.Person.Email,
        FirstName: f.Person.FirstName,
        LastName: f.Person.LastName,
        Followers: f.Random.Int(1, 100),
        Following: f.Random.Int(1, 100),
        Stars: f.Random.Int(1, 100),
        Status: _status?.Name ?? f.PickRandom<ContributorStatus>(ContributorStatus.List).Name,
        CreatedOn: f.Date.Past(),
        ModifiedOn: f.Date.Past(),
        ContributionCount: f.Random.Int(100, 1000),
        NumberOfDaysInStreak: f.Random.Int(7, 10),
        LongestStreakEver: f.Random.Int(11, 100),
        MostContributionsInOneDay: f.Random.Int(10, 20)));

    return faker.Generate();
  }

  /// <summary>
  /// Alternative Faker for a <see cref="ContributorDTO"/> if you want to use a class that inherits from <see cref="Faker{T}"/>.
  /// </summary>
  private class ContributorDTOFaker : Faker<ContributorDTO>
  {
    private int _id;
    private ContributorStatus? _status;

    public ContributorDTOFaker(int? id, ContributorStatus? status)
    {
      _id = id ?? 1; // default to 1 if not provided
      _status = status;

      CustomInstantiator(f => new ContributorDTO(
        Id: _id,
        Email: f.Person.Email,
        FirstName: f.Person.FirstName,
        LastName: f.Person.LastName,
        Followers: f.Random.Int(1, 100),
        Following: f.Random.Int(1, 100),
        Stars: f.Random.Int(1, 100),
        Status: _status?.Name ?? f.PickRandom<ContributorStatus>(ContributorStatus.List).Name,
        CreatedOn: f.Date.Past(),
        ModifiedOn: f.Date.Past(),
        ContributionCount: f.Random.Int(100, 1000),
        NumberOfDaysInStreak: f.Random.Int(7, 10),
        LongestStreakEver: f.Random.Int(11, 100),
        MostContributionsInOneDay: f.Random.Int(10, 20)));
    }
  }
}