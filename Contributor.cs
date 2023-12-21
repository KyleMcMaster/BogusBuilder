using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace BogusBuilder;

public class Contributor(
  string email,
  string firstName,
  string lastName,
  int followers,
  int following,
  int stars,
  string status) : EntityBase, IAggregateRoot
{
  public string Email { get; internal set; } = Guard.Against.NullOrEmpty(email, nameof(email));
  public string FirstName { get; set; } = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
  public string LastName { get; internal set; } = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
  public int Followers { get; internal set; } = Guard.Against.Negative(followers, nameof(followers));
  public int Following { get; internal set; } = Guard.Against.Negative(following, nameof(following));
  public int Stars { get; internal set; } = Guard.Against.Negative(stars, nameof(stars));
  public string Status { get; internal set; } = Guard.Against.NullOrEmpty(status, nameof(status));
}