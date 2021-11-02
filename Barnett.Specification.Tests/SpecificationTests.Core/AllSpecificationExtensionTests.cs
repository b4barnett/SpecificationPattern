using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AllSpecificationExtensionTests
    {
        #region All Specification Extension

        [Test]
        public void AllSpecification_SpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void AllSpecification_OnlyLeftSpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AllSpecification_OnlyRight1SpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AllSpecification_OnlyRight2SpecificationTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void AllSpecification_AllRightSpecificationsTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Matches( Unit.None ).Should().BeFalse();
        }


        [Test]
        public void AllExtension_CreatesAndSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> andSpecification = ( new[] { left, right, right2 } ).All();

            andSpecification.Should().BeOfType<AndSpecification<Unit>>();
        }

        #endregion
    }
}
