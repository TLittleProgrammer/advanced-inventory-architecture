using System;

namespace LocalPackages.Common
{
    public interface ITrigger
    {
        event Action OnCall;
    }
    
    public interface ITrigger<out TParam>
    {
        event Action<TParam> OnCall;
    }
    
    public interface ITrigger<out TParam1, out TParam2>
    {
        event Action<TParam1, TParam2> OnCall;
    }
}