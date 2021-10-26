using Barnett.Specification.Interface;

namespace Barnett.Specification.Sample.FizzBuzz
{
    public class ModuloIsZeroSpecification : ISpecification<int>
    {
        private readonly int _moduloValue;

        public ModuloIsZeroSpecification( int moduloValue )
        {
            _moduloValue = moduloValue;
        }

        public bool Matches( int value )
        {
            return value % _moduloValue == 0;
        }
    }
}