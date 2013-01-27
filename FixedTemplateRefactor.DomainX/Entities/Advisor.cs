using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FixedTemplateRefactor.DomainX.Entities
{
    public enum SomeProfileIndicator
    {
        Risky,
        Balanced,
        LowRisk
    }

    public class Advisor
    {
        public String Name { get; set; }
        public int AdvisorId { get; set; }
        public SomeProfileIndicator ProfileIndicator { get; set; }
        
        /// <summary>
        /// nav property
        /// </summary>
        /// 
        [Required]
        public virtual Customer Customer { get; set; }

        public Advisor()
        {
        }

        public Advisor(SomeProfileIndicator indicator)
        {
            this.ProfileIndicator = indicator;
        }
    }
}
