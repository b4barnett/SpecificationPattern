namespace Barnett.Specification.Interface
{
    /// <summary>
    /// Specification is a true/false evaluation of a particular value represented by this generic
    /// </summary>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Indicates if the value meets the required specification as defined by the type
        /// </summary>
        bool Matches( T value );
    }
}
