using System;
using System.Collections.Generic;
namespace g4m4nez.Models
{
    // TODO: Consider struct
    [Serializable]
    public class WalletRegistry
    {
        private readonly List<Guid> _owned;
        private readonly List<Guid> _used;

        public List<Guid> Owned => _owned;
        public List<Guid> Used => _used;

        public WalletRegistry()
        {
            _owned = new List<Guid>();
            _used = new List<Guid>();
        }

        public void AddOwnedWallet(Guid walletGuid)
        {
            Owned.Add(walletGuid);
        }

        public void RemoveOwnedWallet(Guid walletGuid)
        {
            Owned.Remove(walletGuid);
        }

        public void AddUsedWallet(Guid walletGuid)
        {
            Used.Add(walletGuid);
        }

        public void RemoveUsedWallet(Guid walletGuid)
        {
            Used.Remove(walletGuid);
        }
    }
}