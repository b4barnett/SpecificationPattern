using Barnett.Specification.Core;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AlwaysFalseSpecificationTests
    {
        [Test]
        public void AlwaysFalseSpecification_Should_EvaluateFalse()
        {
            ( new AlwaysFalseSpecification<Unit>() ).Matches( Unit.None ).Should().BeFalse();
        }

        [Test]
        public void FalseBooleanToSpecification_Should_BeAlwaysFalseSpecification()
        {
            false.ToSpecification<Unit>().Should().BeOfType<AlwaysFalseSpecification<Unit>>();
        }
    }
}