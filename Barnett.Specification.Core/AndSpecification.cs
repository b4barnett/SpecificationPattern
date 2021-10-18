using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    /// <summary>
    /// Specification in which two specifications are supplied, both specifications
    /// must evaluate to true for this specification to be true
    /// </summary>
    public class AndSpecification<T> : ISpecification<T> //TODO: Make this internal
    {
        private readonly ISpecification<T> _right;
        private readonly ISpecification<T> _left;

        public AndSpecification( ISpecification<T> left, ISpecification<T> right )
        {
            _right = right;
            _left = left;
        }


        public bool Matches( T value ) => _left.Matches( value ) && _right.Matches( value );
    }
}