using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    /// <summary>
    /// Specification in which two specifications are supplied, one or the other can evaluate to true for this specification to be true
    /// if the two supplied specifications evaluate to the same value, then this specification evaluates to false
    /// </summary>
    public class XOrSpecification<T> : ISpecification<T> //TODO: Mark this internal
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public XOrSpecification( ISpecification<T> left, ISpecification<T> right )
        {
            _left = left;
            _right = right;
        }

        public bool Matches( T value ) => _left.Matches( value ) != _right.Matches( value );
    }
}