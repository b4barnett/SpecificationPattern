using Barnett.Specification.Core;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AlwaysTrueSpecificationTests
    {
        [Test]
        public void AlwaysTrueSpecification_Should_EvaluateTrue()
        {
            ( new AlwaysTrueSpecification<Unit>() ).Matches( Unit.None ).Should().BeTrue();
        }

        [Test]
        public void TrueBooleanToSpecification_ShouldBe_AlwaysTrueSpecification()
        {
            true.ToSpecification<Unit>().Should().BeOfType<AlwaysTrueSpecification<Unit>>();
        }
    }
}