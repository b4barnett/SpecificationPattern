using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class OrTests
    {
        [Test]
        public void OrSpecification_BothSpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> OrSpecification = new OrSpecification<Unit>( left, right );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_OnlyLeftSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> OrSpecification = new OrSpecification<Unit>( left, right );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_OnlyRightSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = new OrSpecification<Unit>( left, right );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrSpecification_BothSpecificationFalse_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = new OrSpecification<Unit>( left, right );

            OrSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void OrExtension_CreatesOrSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = left.Or( right );

            OrSpecification.Should().BeOfType<OrSpecification<Unit>>();
        }
    }
}