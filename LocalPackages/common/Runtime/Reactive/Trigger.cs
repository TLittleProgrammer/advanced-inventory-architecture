using System;

namespace LocalPackages.Common
{
    public sealed class Trigger<TParam> : ITrigger<TParam>
    {
        public event Action<TParam> OnCall;

        public void Call(TParam param)
        {
            OnCall?.Invoke(param);
        }
    }
    
    public sealed class Trigger<TParam1, TParam2> : ITrigger<TParam1, TParam2>
    {
        public event Action<TParam1, TParam2> OnCall;

        public void Call(TParam1 param1, TParam2 param2)
        {
            OnCall?.Invoke(param1, param2);
        }
    }
}