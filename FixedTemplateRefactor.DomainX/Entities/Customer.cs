using FixedTemplateRefactor.DomainX.Exceptions;
using FixedTemplateRefactor.DomainX.FactoryInterfaces;
using FixedTemplateRefactor.DomainX.Specifications;

using Ninject;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FixedTemplateRefactor.DomainX.Services;
using log4net;

namespace FixedTemplateRefactor.DomainX.Entities
{
    /// <summary>
    /// aggregate root entity 
    /// </summary>
    public class Customer 
    {
        [Key, ForeignKey("Advisor")]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Address> addresses { get; set; }

        private static readonly ILog log = LogManager.GetLogger(typeof(Customer));

        /// <summary>
        /// 1 to 1 relationship with Advisor (Entity, EF table)
        /// </summary>
        public Advisor Advisor { get; set; }

        /// <summary>
        /// 1 to 1 relationship with Instruction (value type)
        /// </summary>
        public AccountInstruction ActiveInstruction { get; set; }

        private ISpecification<string> postCodeAreaSpec;
        private ISpecification<string> postCodeFormatSpec;
        private ICustomerChildEntityFactory childEntityFactory; 
        
        public Customer()
        {
        }

        /// <summary>
        /// Aggregate root entity.
        /// </summary>
        /// <param name="pCodeAreaSpec"></param>
        /// <param name="pCodeFormatSpec"></param>
        /// <param name="customerSupportFactory"></param>
        public Customer([Named("PostCodeAreaSpecRequiredAttribute")] ISpecification<string> pCodeAreaSpec, 
                        [Named("PostCodeFormatSpecRequiredAttribute")] ISpecification<string> pCodeFormatSpec, ICustomerChildEntityFactory customerSupportFactory)
        {
            // note could have passed in and array of spec as well.
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
            if (string.IsNullOrEmpty(postCode))
            {
                log.Error("AddAddressBy invoked with an empty or null postcode");
                throw new System.ArgumentNullException(postCode, "postCode is required");
            }

            log.DebugLogIfEnabled("Add Address requested using postcode " + postCode);
            
            if (this.postCodeAreaSpec.And(this.postCodeFormatSpec).IsSatisfiedBy(postCode))
            {
                this.addresses.Add(childEntityFactory.createAddressInstance(true));
                this.Advisor = childEntityFactory.createProfileInstance(SomeProfileIndicator.Balanced);
                log.DebugLogIfEnabled("Address and Profile has been created");
            }
            else
            {
                log.Error("postcode : " + postCode + " Failed Validation");
                throw new PostCodeInvalidException();
            }
        }
    }
}