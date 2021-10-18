using System.Threading.Tasks;

namespace Barnett.Specification.Interface
{
    /// <summary>
    /// Async representation of a specification
    /// </summary>
    public interface ISpecificationAsync<T>
    {
        /// <summary>
        /// Indicates if the value meets the required specification as defined by the type
        /// </summary>
        Task<bool> Matches( T value );
    }
}