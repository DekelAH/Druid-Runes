using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Models", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<float> ManaAmountChange;

        #endregion

        #region Editor

        [SerializeField]
        private float _manaAmount;

        #endregion

        #region Methods

        public void AddMana(float manaToAdd)
        {
            _manaAmount = Mathf.Clamp(_manaAmount + manaToAdd, 0, 100);
            ManaAmountChange?.Invoke(_manaAmount);
        }

        public void TakeMana(float manaToTake)
        {
            _manaAmount = Mathf.Max(0, _manaAmount - manaToTake);
            ManaAmountChange?.Invoke(_manaAmount);
        }

        #endregion

        #region Properties

        public float ManaAmount => _manaAmount;

        #endregion


    }
}
