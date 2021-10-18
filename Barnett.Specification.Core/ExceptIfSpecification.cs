using System.Runtime.CompilerServices;
using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    /// <summary>
    /// Specification in which this only resolves to true if the supplied specification is true and the alternate
    /// specification is false
    /// </summary>
    public class ExceptIfSpecification<T> : ISpecification<T> //TODO: make this internal
    {
        private readonly ISpecification<T> _specification;
        private readonly ISpecification<T> _exceptIfSpecification;

        public ExceptIfSpecification( ISpecification<T> specification, ISpecification<T> exceptIfSpecification )
        {
            _specification = specification;
            _exceptIfSpecification = exceptIfSpecification;
        }

        public bool Matches( T value )
        {
            bool specResult = _specification.Matches( value );
            if( specResult )
            {
                bool exceptResult = _exceptIfSpecification.Matches( value );

                return !exceptResult;
            }

            return false;
        }
    }
}