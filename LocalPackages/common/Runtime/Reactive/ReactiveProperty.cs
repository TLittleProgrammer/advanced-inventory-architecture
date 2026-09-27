using System;
using System.Collections.Generic;

namespace LocalPackages.Common
{
    public class ReactiveProperty<TValue> where TValue : IEquatable<TValue>
    {
        public event Action<TValue, TValue> Changed;
        
        private TValue _value;
        
        public TValue Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(_value, value))
                {
                    var oldValue = _value;
                    _value = value;
                    
                    Changed?.Invoke(oldValue, _value);
                }
            }
        }
    }
}