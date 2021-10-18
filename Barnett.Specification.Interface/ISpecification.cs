using System;
using System.Threading.Tasks;

namespace Barnett.Specification.Interface
{
    public interface ISpecification<T>
    {
        bool Matches( T value );
    }

    public interface ISpecificationAsync<T>
    {
        Task<bool> Matches( T value );
    }
}
