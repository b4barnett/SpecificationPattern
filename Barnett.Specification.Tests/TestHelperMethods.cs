using Barnett.Specification.Interface;
using Moq;

namespace Barnett.Specification.Tests
{
    public static class TestHelperMethods
    {
        public static ISpecification<Unit> SetupMockSpecification( bool toEvaluateToo )
        {
            Mock<ISpecification<Unit>> moqSpec = new Mock<ISpecification<Unit>>();
            moqSpec.Setup( x => x.Matches( Unit.None ) ).Returns( toEvaluateToo );
            return moqSpec.Object;
        }
    }
}