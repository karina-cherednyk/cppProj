using System;

namespace g4m4nez.GUI.WPF.Navigation
{
    public interface INavigatable<TOBject> where TOBject : Enum
    {
        public TOBject Type { get; }
        public void ClearSensitiveData();
    }
}
