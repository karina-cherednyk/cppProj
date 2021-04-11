using g4m4nez.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace g4m4nez.Utils
{
    public class StorableList<T> : List<T>, IStorable
    {
        private Guid _guid;
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
    }
}
