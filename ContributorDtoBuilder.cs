using System;

namespace BogusBuilder
{
    public class ContributorDtoBuilderV1
    {
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
            _email = "test@email.com";
            _firstName = "Test";
            _lastName = "User";
            _followers = 1;
            _following = 1;
            _stars = 1;
            _status = "active";
            _createdOn = DateTimeOffset.UtcNow;
            _modifiedOn = DateTimeOffset.UtcNow;
            _contributionCount = 1;
            _numberOfDaysInStreak = 1;
            _longestStreakEver = 1;
            _mostContributionsInOneDay = 1;
            return this;
        }

        public ContributorDtoBuilderV1 WithLongestStreakEver(int? longestStreakEver)
        {
            _longestStreakEver = longestStreakEver;
            return this;
        }

        // other With methods excluded

        public ContributorDTO Build()
        {
            return new ContributorDTO(
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
}
