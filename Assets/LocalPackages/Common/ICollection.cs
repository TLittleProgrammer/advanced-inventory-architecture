using System;

namespace LocalPackages.Common
{
    public interface ICollection<TType>
    {
        Action<TType> Added { get; }
        Action<TType> Updated { get; }
        Action<TType> Removed { get; }
    }
}