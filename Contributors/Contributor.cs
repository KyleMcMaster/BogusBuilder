using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Ardalis.SmartEnum;
using System;

namespace BogusBuilder.Contributors;

/// <summary>
/// Contributor Entity from Ardalis.CleanArchitecture template as our example domain entity
/// </summary>
public class Contributor(
  string email,
  string firstName,
  string lastName,
  int followers,
  int following,
  int stars,
  ContributorStatus status) : EntityBase, IAggregateRoot
{
  public string Email { get; internal set; } = Guard.Against.NullOrEmpty(email, nameof(email));
  public string FirstName { get; set; } = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
  public string LastName { get; internal set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
  public int Followers { get; internal set; } = Guard.Against.Negative(followers, nameof(followers));
  public int Following { get; internal set; } = Guard.Against.Negative(following, nameof(following));
  public int Stars { get; internal set; } = Guard.Against.Negative(stars, nameof(stars));
  public ContributorStatus Status { get; internal set; } = Guard.Against.Null(status);
}

public class ContributorStatus : SmartEnum<ContributorStatus>
{
  public static readonly ContributorStatus CoreTeam = new(nameof(CoreTeam), 1);
  public static readonly ContributorStatus Community = new(nameof(Community), 2);
  public static readonly ContributorStatus NotSet = new(nameof(NotSet), 3);

  protected ContributorStatus(string name, int value) : base(name, value) { }
}

public record ContributorDTO(
  int Id,
  string Email,
  string FirstName,
  string LastName,
  int Followers,
  int Following,
  int Stars,
  string Status,
  DateTimeOffset? CreatedOn,
  DateTimeOffset? ModifiedOn,
  int? ContributionCount,
  int? NumberOfDaysInStreak,
  int? LongestStreakEver,
  int? MostContributionsInOneDay);
