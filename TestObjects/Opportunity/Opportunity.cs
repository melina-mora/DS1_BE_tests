using TestObjects.Common.Requests;
using TestObjects.Common.Users;

namespace TestObjects.Opportunity
{
    public class Opportunity : Request
    {
        private string OpportunityTypeCode { get; set; }
        public string LegalEntity { get; set; }

        public User User { get; }

        public Opportunity(User user, string opportunityTypeCode, string legalEntity = null)
        {
            OpportunityTypeCode = opportunityTypeCode;
            User = user;
            LegalEntity = legalEntity is null ? user.LegalEntity : legalEntity;
        }

        public Opportunity CreateNew()
        {
            return this;
        }
    }
}