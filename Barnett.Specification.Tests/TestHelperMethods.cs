using Barnett.Specification.Interface;
using Moq;

namespace Barnett.Specification.Tests
{
    public static class TestHelperMethods
    {
        public static ISpecification<bool?> SetupMockSpecification( bool toEvaluateToo )
        {
            Mock<ISpecification<bool?>> moqSpec = new Mock<ISpecification<bool?>>();
            moqSpec.Setup( x => x.Matches( null) ).Returns( toEvaluateToo );
            return moqSpec.Object;
        }
    }
}