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
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> XOrSpecification = new XOrSpecification<bool?>( left, right );
            
            XOrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_OnlyLeftSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<bool?> XOrSpecification = new XOrSpecification<bool?>( left, right );
            
            XOrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_OnlyRightSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> XOrSpecification = new XOrSpecification<bool?>( left, right );
            
            XOrSpecification.Matches( null ).Should().BeTrue();
        }

        [Test]
        public void XOrSpecification_BothSpecificationFalse_EvaluatesTrue()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> XOrSpecification = new XOrSpecification<bool?>( left, right );
            
            XOrSpecification.Matches( null ).Should().BeFalse();
        }

        [Test]
        public void XOrExtension_CreatesXOrSpecification()
        {
            ISpecification<bool?> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<bool?> left = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<bool?> XOrSpecification = left.XOr( right );

            XOrSpecification.Should().BeOfType<XOrSpecification<bool?>>();
        }
    }
}