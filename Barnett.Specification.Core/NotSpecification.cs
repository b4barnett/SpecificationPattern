using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    /// <summary>
    /// Inverse of the result of the supplied specification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec;

        public NotSpecification( ISpecification<T> spec )
        {
            _spec = spec;
        }

        public bool Matches( T value ) => !_spec.Matches( value );
    }
}