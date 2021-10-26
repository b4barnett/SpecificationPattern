using System.Reflection.Metadata.Ecma335;
using Barnett.Specification.Interface;

namespace Barnett.Specification.Sample.FizzBuzz
{
    //TODO: Should this be promoted to Core package?
    public class AlwaysTrueSpecification : ISpecification<int>
    {
        public bool Matches( int value ) => true;
    }
}