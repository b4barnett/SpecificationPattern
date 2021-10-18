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
            ISpecification<Unit> spec = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> notSpec = new NotSpecification<Unit>( spec );

            notSpec.Matches( Unit.None ).Should().BeFalse();
        }
        
        
        [Test]
        public void NotSpecification_WhenFalse_EvaluatesTrue()
        {
            ISpecification<Unit> spec = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> notSpec = new NotSpecification<Unit>( spec );

            notSpec.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void NotSpecificationExtension_ShouldBeNotSpecification()
        {
            ISpecification<Unit> spec = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> not = spec.Not();

            not.Should().BeOfType<NotSpecification<Unit>>();
        }
    }
}