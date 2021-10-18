using Barnett.Specification.Core;
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

            ISpecification<bool?> notSpec = new NotSpecification<bool?>( spec );

            notSpec.Matches( null ).Should().BeFalse();
        }
        
        
        [Test]
        public void NotSpecification_WhenFalse_EvaluatesTrue()
        {
            ISpecification<bool?> spec = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> notSpec = new NotSpecification<bool?>( spec );

            notSpec.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void NotSpecificationExtension_ShouldBeNotSpecification()
        {
            ISpecification<bool?> spec = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> not = spec.Not();

            not.Should().BeOfType<NotSpecification<bool?>>();
        }
    }
}