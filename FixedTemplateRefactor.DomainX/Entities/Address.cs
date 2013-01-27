using System;

namespace FixedTemplateRefactor.DomainX.Entities
{
    public class Address
    {
        private bool isValid;

        public int AddressID { get; set; }

        public bool IsValid
        {
            get
            {
                return isValid; 
            }
            set
            { 
                isValid = value; 
            }
        }

        /// <summary>
        /// navigation property
        /// </summary>
        public int CustomerId { get; set; }
         
        public virtual Customer Customer { get; set; }

        public Address()
        {
        }

        public Address(Boolean isAddressValid)
        {
            isValid = isAddressValid;
        }
    }
}
