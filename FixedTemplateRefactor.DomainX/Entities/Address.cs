using System;

namespace FixedTemplateRefactor.DomainX.Entities
{
    public class Address
    {
        private bool isvalid;

        public  int AddressID { get; set; }

        public Address(Boolean isAddressValid)
        {
            isvalid = isAddressValid;
        }

        public bool IsValid { get; set; }
    }
}
