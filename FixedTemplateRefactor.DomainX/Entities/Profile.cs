using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FixedTemplateRefactor.DomainX.Entities
{
    public class Profile
    {
        public enum SomeProfileIndicator
        {
            Risky,
            Balanced,
            LowRisk
        }

        public int ProfileId { get; set; }
        public SomeProfileIndicator ProfileIndicator { get; set; }
        
        /// <summary>
        /// nav property
        /// </summary>
        /// 
        [Required]
        public virtual Customer Customer { get; set; }

        public Profile()
        {
        }

        public Profile(SomeProfileIndicator indicator)
        {
            this.ProfileIndicator = indicator;
        }
    }
}
