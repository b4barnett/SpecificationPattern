using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class ExpectIfAnySpecificationTests
    {
        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluateTrue_WhenAllOthersFalse()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo } );

            compositeSpecification.Matches( Unit.None ).Should().BeTrue();
        }
        
        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluateFalse_WhenFirstOtherIsTrue()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo } );

            compositeSpecification.Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluateFalse_WhenSecondOtherIsTrue()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo } );

            compositeSpecification.Matches( Unit.None ).Should().BeFalse();
        }
        
        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluateFalse_WhenThirdOtherIsTrue()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherThree = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo, otherThree } );

            compositeSpecification.Matches( Unit.None ).Should().BeFalse();
        }

    }
}