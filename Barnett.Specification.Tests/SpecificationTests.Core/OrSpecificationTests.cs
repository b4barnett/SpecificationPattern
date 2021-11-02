using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class OrTests
    {
        #region Or Specifications
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

        #endregion

        #region OrAny

        #region Or Specifications
        [Test]
        public void OrAnySpecification_AllSpecificationsTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrAnySpecification_OnlyLeftSpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrAnySpecification_OnlyRight1SpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrAnySpecification_OnlyRight2SpecificationTrue_EvaluatesTrue()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void OrAnySpecification_AllSpecificationFalse_EvaluatesFalse()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void OrAnyExtension_CreatesOrSpecification()
        {
            ISpecification<Unit> right = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> left = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> right2 = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> OrSpecification = left.OrAny( new[] { right, right2 } );

            OrSpecification.Should().BeOfType<OrSpecification<Unit>>();
        }

        #endregion 

        #endregion 
    }
}