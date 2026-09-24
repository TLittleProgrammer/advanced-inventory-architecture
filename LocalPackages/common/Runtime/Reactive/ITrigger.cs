using System;

namespace LocalPackages.Common
{
    public interface ITrigger<TParam>
    {
        event Action<TParam> OnCall;
    }
    
    public interface ITrigger<TParam1, TParam2>
    {
        event Action<TParam1, TParam2> OnCall;
    }
}