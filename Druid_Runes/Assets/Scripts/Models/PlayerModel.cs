using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Models", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<float> ManaAmountChange;
        public event Action<float> HealthChange;

        #endregion

        #region Editor

        [SerializeField]
        private float _manaAmount;

        [SerializeField]
        private float _healthAmount;

        #endregion

        #region Fields

        private string _modelName = "";

        #endregion

        #region Methods

        public void Initialize(float health, float mana)
        {
            _healthAmount = health;
            _manaAmount = mana;
        }

        public void AddHealth(float healthToAdd)
        {
            _healthAmount = Mathf.Clamp(_healthAmount + healthToAdd, 0, 100);
            HealthChange?.Invoke(_healthAmount);
        }

        public void TakeHealth(float healthToTake)
        {
            _healthAmount = Mathf.Max(0, _healthAmount - healthToTake);
            HealthChange?.Invoke(_healthAmount);
        }

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

        public string SetModelName(string modelName)
        {
            return _modelName = modelName;
        }

        #endregion

        #region Properties

        public float ManaAmount => _manaAmount;
        public float HealthAmount => _healthAmount;
        public string ModelName => _modelName;

        #endregion


    }
}
