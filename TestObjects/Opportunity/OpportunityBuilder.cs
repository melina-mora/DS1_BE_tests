using System.Collections.Generic;
using TestObjects.Common.Users;

namespace TestObjects.Opportunity
{
    public class OpportunityBuilder
    {
        public string OpportunityCode { get; set; }
        public string LegalEntity { get; set; }

        public Dictionary<string, string> AddressTestData { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> BusinessLineTestData { get; set; } = new Dictionary<string, string>();
        public User User { get; set; }

        public OpportunityBuilder SetUser(User user)
        {
            LegalEntity = user.LegalEntity;
            User = user;
            return this;
        }

        public OpportunityBuilder SetLegalEntity(string legalEntity)
        {
            LegalEntity = legalEntity;
            return this;
        }

        public OpportunityBuilder SetOpportunityCode(string opportunityCode)
        {
            OpportunityCode = opportunityCode;
            return this;
        }

        public Opportunity Build()
        {
            var opportunity = new Opportunity(User, OpportunityCode, LegalEntity);
            return opportunity;
        }
    }
}