using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    /// <summary>
    /// Specification in which two specifications are supplied, either specifications
    /// can evaluate to true for this specification to be true
    /// </summary>
    public class OrSpecification<T> : ISpecification<T> //TODO: Make this internal
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification( ISpecification<T> left, ISpecification<T> right )
        {
            _left = left;
            _right = right;
        }

        public bool Matches( T value ) => _left.Matches( value ) || _right.Matches( value );
    }
}