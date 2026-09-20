using System;

namespace LocalPackages.Common
{
    public interface ICollection<TType>
    {
        event Action<TType> Added;
        event Action<TType> Updated;
        event Action<TType> Removed;
    }
}