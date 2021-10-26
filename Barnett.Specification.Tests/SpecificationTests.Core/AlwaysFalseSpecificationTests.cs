using Barnett.Specification.Core;
using FluentAssertions;

namespace Barnett.Specification.Tests.SpecificationTests.Core
{
    public class AlwaysFalseSpecificationTests
    {
        public void AlwaysFalseSpecification_Should_EvaluateFalse()
        {
            ( new AlwaysFalseSpecification<Unit>() ).Matches( Unit.None ).Should().BeFalse();
        }
    }
}