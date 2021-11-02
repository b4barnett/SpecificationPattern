using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AndTests
    {
        #region And specification

        [Test]
        public void AndSpecification_BothSpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = new AndSpecification<Unit>( left, right );

            andSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void AndSpecification_OnlyLeftSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = new AndSpecification<Unit>( left, right );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndSpecification_OnlyRightSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = new AndSpecification<Unit>( left, right );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndSpecification_BothSpecificationFalse_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = new AndSpecification<Unit>( left, right );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndExtension_CreatesAndSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = left.And( right );

            andSpecification.Should().BeOfType<AndSpecification<Unit>>();
        }

        #endregion

        #region AndAll Specification Extension

        [Test]
        public void AndAllSpecification_SpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void AndAllSpecification_OnlyLeftSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndAllSpecification_OnlyRight1SpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndAllSpecification_OnlyRight2SpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AndAllSpecification_AllRightSpecificationsTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }


        [Test]
        public void AndAllExtension_CreatesAndSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = left.AndAll( new[] { right, right2 } );

            andSpecification.Should().BeOfType<AndSpecification<Unit>>();
        }

        #endregion
    }
}