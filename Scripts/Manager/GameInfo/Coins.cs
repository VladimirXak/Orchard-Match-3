using System;
using UnityEngine.Events;

namespace Orchard.GameSpace
{
    public class Coins
    {
        public event UnityAction<int> OnChange;

        private Action<bool> OnSaveData;

        private SecureInt _value;
        public SecureInt Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
                OnChange?.Invoke(value);
            }
        }

        public void Init(int coins, Action<bool> saveData)
        {
            Value = coins;
            OnSaveData = saveData;
        }

        public bool TryBuy(int price, bool isSave = true)
        {
            if (Value >= price)
            {
                Buy(price, isSave);
                return true;
            }

            return false;
        }

        public void AddCoins(int countCoins, bool isSave = true)
        {
            Value += countCoins;
            OnSaveData(isSave);
        }

        private void Buy(int price, bool isSave)
        {
            Value -= price;
            OnSaveData(isSave);
        }
    }
}
