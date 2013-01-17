using FixedTemplateRefactor.DomainX.Exceptions;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;

namespace FixedTemplateRefactor.DomainX.Entities
{
    /// <summary>
    /// entity for demonstration purposes
    /// </summary>
    public class Customer 
    {
        private Address address;
        private PostCodeAreaSpecification postCodeAreaSpec;
        private PostCodeFormatSpecification postCodeFormatSpec;
        private Address activeAddress;
        private IAddressFactory addressFactory; 

        public Customer()
        {
        }

        public Customer(PostCodeAreaSpecification spec, PostCodeFormatSpecification spec2, IAddressFactory addressFactory)
        {
            this.postCodeAreaSpec = spec;
            this.postCodeFormatSpec = spec2;
            this.addressFactory = addressFactory;
        }

        public int CustomerID { get; set; }

        public Address ActiveAddress 
        { 
            get { return activeAddress;}
        }


        /// <summary>
        /// demo use of injected in rules
        /// </summary>
        /// <param name="postCode">valid postcode format in appropriate area for customer</param>
        /// <exception cref="PostCodeInvalidException">if PostCode is not in allowed area or format invalid</exception>
        public void SetAddressBy(string postCode)
        {
            if (this.postCodeAreaSpec.And(this.postCodeFormatSpec).IsSatisfiedBy(postCode))
            {
                this.activeAddress = addressFactory.getInstance(true);
            }
            else
            {
                throw new PostCodeInvalidException();
            }
        }
    }
}