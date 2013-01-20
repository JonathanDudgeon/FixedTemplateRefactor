using FixedTemplateRefactor.DomainX.Exceptions;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;

using Ninject;
using System.Collections.Generic;

namespace FixedTemplateRefactor.DomainX.Entities
{
    /// <summary>
    /// entity for demonstration purposes
    /// </summary>C:\work\web\FixedTemplateRefactor\FixedTemplateRefactor.DomainX\Entities\Customer.cs
    public class Customer 
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Address> addresses { get; set; }
        private ISpecification<string> postCodeAreaSpec;
        private ISpecification<string> postCodeFormatSpec;
        private IAddressFactory addressFactory; 

        public Customer()
        {
        }

        // note could just have easily passed in an array of specs here and used multi injection
        // could also have used named bindings
        //
        public Customer([Named("PostCodeAreaSpecRequiredAttribute")] ISpecification<string> pCodeAreaSpec, 
                        [Named("PostCodeFormatSpecRequiredAttribute")] ISpecification<string> pCodeFormatSpec, IAddressFactory addressFactory)
        {
            this.postCodeAreaSpec = pCodeAreaSpec;
            this.postCodeFormatSpec = pCodeFormatSpec;
            this.addressFactory = addressFactory;
            this.addresses = new List<Address>();
        }
      
        /// <summary>
        /// demo use of injected in rules
        /// </summary>
        /// <param name="postCode">valid postcode format in appropriate area for customer</param>
        /// <exception cref="PostCodeInvalidException">if PostCode is not in allowed area or format invalid</exception>
        public void AddAddressBy(string postCode)
        {
            if (this.postCodeAreaSpec.And(this.postCodeFormatSpec).IsSatisfiedBy(postCode))
            {
                this.addresses.Add(addressFactory.getInstance(true));
            }
            else
            {
                throw new PostCodeInvalidException();
            }
        }
    }
}