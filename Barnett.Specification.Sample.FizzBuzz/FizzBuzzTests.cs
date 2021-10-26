using System;
using System.Collections.Generic;
using System.Linq;
using Barnett.Specification.Core;
using Barnett.Specification.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace Barnett.Specification.Sample.FizzBuzz
{
    public class FizzBuzzTests
    {
        [Test]
        public void FizzBuzz()
        {
            int[] insert = new[]
            {
                1, 2, 3, 4, 5,
                6, 7, 8, 9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19, 20,
                21, 22, 23, 24, 25,
                26, 27, 28, 29, 30
            };

            string[] expected = new[]
            {
                "1", "2", "Fizz", "4", "Buzz",
                "Fizz", "7", "8", "Fizz", "Buzz",
                "11", "Fizz", "13", "14", "FizzBuzz",
                "16", "17", "Fizz", "19", "Buzz",
                "Fizz", "22", "23", "Fizz", "Buzz",
                "26", "Fizz", "28", "29", "FizzBuzz"
            };

            List<string> output = new List<string>();

            var threeSpec = CreateModuloSpecification( 3, new[] { 5, 15 }, () => output.Add( "Fizz" ) );
            var fiveSpec = CreateModuloSpecification( 5, new[] { 3, 15 }, () => output.Add( "Buzz" ) );
            var fifteenSpec = CreateModuloSpecification( 15, new int[ 0 ], () => output.Add( "FizzBuzz" ) );
            var catchElse = CreateCatchAllSpecification( new[] { 3, 5, 15 }, i => output.Add( i.ToString() ) );
            
            FizzBuzz( insert, new[] { threeSpec, fiveSpec, fifteenSpec, catchElse } );

            output.Should().BeEquivalentTo( expected );
        }

        private ActionSpecification<int> CreateModuloSpecification( int value, int[] except, Action action )
        {
            var targetSpecification = new ModuloIsZeroSpecification( value );
            var doNotTargetSpecification = except.Select( x => new ModuloIsZeroSpecification( x ) );

            return targetSpecification.ExceptIfAny( doNotTargetSpecification ).Do( n => action() );
        }

        private ActionSpecification<int> CreateCatchAllSpecification( int[] except, Action<int> action )
        {
            var specification = new AlwaysTrueSpecification<int>();
            var doNotTargetSpecifications = except.Select( x => new ModuloIsZeroSpecification( x ) );

            return specification.ExceptIfAny( doNotTargetSpecifications ).Do( action );
        }

        /// <summary>
        /// This will handle the bulk of the fizz buzz testing
        /// </summary>
        private static void FizzBuzz( int[] values, IEnumerable<ActionSpecification<int>> specifications )
        {
            foreach( int value in values )
            {
                foreach( var specification in specifications )
                {
                    if( specification.Matches( value ) )
                    {
                        specification.Do( value );
                    }
                }
            }
        }
    }
}