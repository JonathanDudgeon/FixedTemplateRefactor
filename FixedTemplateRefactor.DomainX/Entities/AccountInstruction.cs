using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.DomainX.Entities
{
    public enum PolicyStatuses
    {
        ApplicationPending,
        Active,
        NoActiveAccount
    }

    /// <summary>
    /// Immutable value type.  EF will infer as Complex type through convention
    /// </summary>
    public class AccountInstruction
    {
        // --------------------------------------------------
        // note complex types do not contain navigation props
        // as EF needs access to the props, rather than having read only fields
        // to enforce immutability I have compromised slightly with private sets
        // --------------------------------------------------

        private  PolicyStatuses polStatus;
        private String comment = "";

        public PolicyStatuses PolicyStatus
        {
            get 
            { 
                return polStatus; 
            }
            private set
            {
                polStatus = value; 
            }
        }

        public String Comment 
        { 
            get
            {
                return comment;
            }
            private set
            {
                comment = value;
            }
        }

        public AccountInstruction(PolicyStatuses status, String instructionComment)
        {
            this.polStatus = status;
            this.comment = instructionComment;
        }
    }
}
