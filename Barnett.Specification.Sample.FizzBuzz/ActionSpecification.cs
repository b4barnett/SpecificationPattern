using System;
using Barnett.Specification.Interface;

namespace Barnett.Specification.Sample.FizzBuzz
{
    //TODO: Should I promote the action specification to the core or an extensions project?
    public class ActionSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _innerSpecification;
        private readonly Action<T> _action;

        public ActionSpecification( ISpecification<T> innerSpecification, Action<T>  action )
        {
            _innerSpecification = innerSpecification;
            _action = action;
        }

        //we could do the action as part of the matches but it does render the resulting bool as moot
        public bool Matches( T value ) => _innerSpecification.Matches( value );

        public void Do( T value )
        {
            _action( value );
        }
    }

    public static class ActionSpecificationExtensions
    {
        public static ActionSpecification<T> Do<T>( this ISpecification<T> spec, Action<T> action ) 
            => new ActionSpecification<T>( spec, action );
    }
}