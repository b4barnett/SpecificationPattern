using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class XOrTests
    {
        [Test]
        public void XOrSpecification_BothSpecificationsTrue_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> XOrSpecification = new XOrSpecification<Unit>( left, right );
            
            XOrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_OnlyLeftSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> XOrSpecification = new XOrSpecification<Unit>( left, right );
            
            XOrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_OnlyRightSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> XOrSpecification = new XOrSpecification<Unit>( left, right );
            
            XOrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_BothSpecificationFalse_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> XOrSpecification = new XOrSpecification<Unit>( left, right );
            
            XOrSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void XOrExtension_CreatesXOrSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> XOrSpecification = left.XOr( right );

            XOrSpecification.Should().BeOfType<XOrSpecification<Unit>>();
        }
    }
}