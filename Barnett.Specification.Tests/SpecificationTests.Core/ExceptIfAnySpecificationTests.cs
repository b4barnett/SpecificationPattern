using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class ExpectIfAnySpecificationTests
    {
        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluteTrue_WhenAllOthersFalse()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( false );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo } );

            compositeSpecification.Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void ExceptIfAny_OriginalSpecificationEvaluteFalse_WhenAnyOthersTrue()
        {
            ISpecification<Unit> specification = TestHelperMethods.SetupMockSpecification( true );
            ISpecification<Unit> otherOne = TestHelperMethods.SetupMockSpecification( false );
            ISpecification<Unit> otherTwo = TestHelperMethods.SetupMockSpecification( true );

            ISpecification<Unit> compositeSpecification = specification.ExceptIfAny( new[] { otherOne, otherTwo } );

            compositeSpecification.Matches( Unit.None ).Should().BeFalse();
        }

    }
}