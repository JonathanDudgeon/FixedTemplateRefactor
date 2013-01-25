using FixedTemplateRefactor.DomainX.Exceptions;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;

using Ninject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedTemplateRefactor.DomainX.Entities
{
    /// <summary>
    /// aggregate root entity 
    /// </summary>
    public class Customer 
    {
        [Key, ForeignKey("Profile")]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Address> addresses { get; set; }

        public Profile Profile { get; set; }

        private ISpecification<string> postCodeAreaSpec;
        private ISpecification<string> postCodeFormatSpec;
        private ICustomerChildEntityFactory childEntityFactory; 
        

        public Customer()
        {
        }

        // note could just have easily passed in an array of specs here and used multi injection
        // could also have used named bindings
        //
        public Customer([Named("PostCodeAreaSpecRequiredAttribute")] ISpecification<string> pCodeAreaSpec, 
                        [Named("PostCodeFormatSpecRequiredAttribute")] ISpecification<string> pCodeFormatSpec, ICustomerChildEntityFactory customerSupportFactory)
        {
            this.postCodeAreaSpec = pCodeAreaSpec;
            this.postCodeFormatSpec = pCodeFormatSpec;
            this.childEntityFactory = customerSupportFactory;
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
                this.addresses.Add(childEntityFactory.createAddressInstance(true));
                this.Profile = childEntityFactory.createProfileInstance(Profile.SomeProfileIndicator.Balanced);
            }
            else
            {
                throw new PostCodeInvalidException();
            }
        }
    }
}