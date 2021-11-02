﻿using System;
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
            spec.ExpectIf( specifications.Aggregate( ( (ISpecification<T>)new AlwaysFalseSpecification<T>() ),
                ( specification, specification1 ) => specification.Or( specification1 ) ) );

        public static ISpecification<T> AndAll<T>( this ISpecification<T> left, 
            IEnumerable<ISpecification<T>> rightSpecifications ) =>
            left.And( rightSpecifications.Aggregate( ( (ISpecification<T>)new AlwaysTrueSpecification<T>() ), 
                ( spec, rightSpec ) => spec.And( rightSpec ) ) );

        public static ISpecification<T> OrAny<T>( this ISpecification<T> left, 
            IEnumerable<ISpecification<T>> rightSpecification ) =>
            left.Or( rightSpecification.Aggregate( (ISpecification<T>)new AlwaysFalseSpecification<T>(), 
                ( spec, rightSpec ) => spec.Or( rightSpec ) ) );


        /// <summary>
        /// Will evalute to a specification that will always resolve to the give boolean state of <see cref="state"/>
        /// </summary>
        /// <typeparam name="T">The type for the specification to accept</typeparam>
        /// <param name="state">The value the specification should evalute to</param>
        /// <returns>Specification that resolves to the given value of <see cref="state"/></returns>
        /// <remarks>Although not particular useful on its own, this extension makes working in a more functional work like 
        /// when using <see cref="System.Linq.Enumerable.Aggregate{TSource}(IEnumerable{TSource}, Func{TSource, TSource, TSource})"/> easier</remarks>
        public static ISpecification<T> ToSpecification<T>( this bool state ) => state ? (ISpecification<T>)new AlwaysTrueSpecification<T>() : new AlwaysFalseSpecification<T>();
    }
}