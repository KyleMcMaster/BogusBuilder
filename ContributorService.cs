using System.Threading.Tasks;

namespace BogusBuilder
{
    public class ContributorService
    {
        public Task SendSomeMessage(ContributorDTO contributorDTO)
        {
            return Task.CompletedTask;
        }
    }
}
