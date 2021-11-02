using System;
using System.Collections.Generic;
using System.Linq;
using Barnett.Specification.Interface;

namespace Barnett.Specification.Core
{
    //TODO: add comments to these extensions
    public static class Specifications
    {
        public static ISpecification<T> And<T>( this ISpecification<T> left, ISpecification<T> right ) =>
            new AndSpecification<T>( left, right );

        public static ISpecification<T> Or<T>( this ISpecification<T> left, ISpecification<T> right ) =>
            new OrSpecification<T>( left, right );

        public static ISpecification<T> XOr<T>( this ISpecification<T> left, ISpecification<T> right ) =>
            new XOrSpecification<T>( left, right );

        public static ISpecification<T> Not<T>( this ISpecification<T> spec ) => new NotSpecification<T>( spec );

        public static ISpecification<T> ExpectIf<T>( this ISpecification<T> spec, ISpecification<T> except ) =>
            new ExceptIfSpecification<T>( spec, except );

        public static ISpecification<T> ExceptIfAny<T>( this ISpecification<T> spec,
            IEnumerable<ISpecification<T>> specifications ) =>
            spec.ExpectIf( specifications.Aggregate( (ISpecification<T>) new AlwaysFalseSpecification<T>(),
                ( specification, specification1 ) => specification.Or( specification1 ) ) );

        public static ISpecification<T> AndAll<T>(this ISpecification<T> left, IEnumerable<ISpecification<T>> rightSpecifications) => throw new NotImplementedException("AndAll Specification not yet satisfied");
    }
}