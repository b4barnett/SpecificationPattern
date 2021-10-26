using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    public class AlwaysFalseSpecification<T> : ISpecification<T>
    {
        public bool Matches( T value ) => false;

    }
}