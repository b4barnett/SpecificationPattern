using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    public class AlwaysTrueSpecification<T> : ISpecification<T>
    {
        public bool Matches( T value ) => true;
    }
}