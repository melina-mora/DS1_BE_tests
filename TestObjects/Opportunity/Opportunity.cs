using TestObjects.Common.Requests;
using TestObjects.Common.Users;

namespace TestObjects.Opportunity
{
    public class Opportunity : Request
    {
        private string OpportunityTypeCode { get; set; }

        public User User { get; }

        public Opportunity(User user, string opportunityTypeCode)
        {
            OpportunityTypeCode = opportunityTypeCode;
            User = user;
        }

        public Opportunity CreateNew(string legalEntity, Dictionary<string, string> body)
        {
        }
    }
}