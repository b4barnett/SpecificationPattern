using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class NotSpecificationTests
    {
        [Test]
        public void NotSpecification_WhenTrue_EvaluatesFalse()
        {
            ISpecification<bool?> spec = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> notSpec = null;

            notSpec.Matches( null ).Should().BeFalse();
        }
        
        
        [Test]
        public void NotSpecification_WhenFalse_EvaluatesTrue()
        {
            ISpecification<bool?> spec = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> notSpec = null;

            notSpec.Matches( null ).Should().BeFalse();
        }
    }
}