using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AndTests
    {
        [Test]
        public void AndSpecification_BothSpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> andSpecification = new AndSpecification<bool?>( left, right );
            
            andSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void AndSpecification_OnlyLeftSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> andSpecification = new AndSpecification<bool?>( left, right );
            
            andSpecification.Matches( null ).Should().BeFalse();
        }

        [Test]
        public void AndSpecification_OnlyRightSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> andSpecification = new AndSpecification<bool?>( left, right );
            
            andSpecification.Matches( null ).Should().BeFalse();
        }

        [Test]
        public void AndSpecification_BothSpecificationFalse_EvaluatesFalse()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> andSpecification = new AndSpecification<bool?>( left, right );
            
            andSpecification.Matches( null ).Should().BeFalse();
        }

        [Test]
        public void AndExtension_CreatesAndSpecification()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> andSpecification = left.And( right );

            andSpecification.Should().BeOfType<AndSpecification<bool?>>();
        }
    }
}