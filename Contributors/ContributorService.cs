using Ardalis.GuardClauses;
using System.Threading.Tasks;

namespace BogusBuilder.Contributors;

/// <summary>
/// Represents a service that sends a message with an integration DTO.
/// </summary>
public class ContributorService
{
  /// <summary>
  /// Should send a message to a queue or some endpoint, but for now just validates and returns a completed task
  /// </summary>
  /// <param name="contributorDTO"></param>
  /// <returns></returns>
  public Task SendSomeMessage(ContributorDTO contributorDTO)
  {
    Guard.Against.NegativeOrZero(contributorDTO.Id, nameof(contributorDTO.Id));
    return Task.CompletedTask;
  }
}

