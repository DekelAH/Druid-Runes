using Assets.Scripts;
using Assets.Scripts.Infastructure;
using Assets.Scripts.Models;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class ManaBar : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Image _manaFillImage;
        
        #endregion

        #region Fields

        private float _currentManaAmount;

        #endregion

        #region Functions

        private void Update()
        {
            UpdateManaBar();
            InitialBarValue();
        }

        private void InitialBarValue()
        {
            var playerModel = SetPlayerModel();
            _currentManaAmount = playerModel.ManaAmount;

            _manaFillImage.fillAmount = _currentManaAmount / 100;
        }

        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.ManaAmountChange -= AddManaAmount;
            playerModel.ManaAmountChange -= TakeManaAmount;
        }

        private void AddManaAmount(float manaAmount)
        {
            _currentManaAmount += manaAmount;
        }

        private void TakeManaAmount(float manaAmount)
        {
            _currentManaAmount -= manaAmount;
        }

        private void UpdateManaBar()
        {
            var playerModel = SetPlayerModel();
            playerModel.ManaAmountChange += AddManaAmount;
            playerModel.ManaAmountChange += TakeManaAmount;         
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            return playerModel;
        }

        #endregion
        
        #region Properties

        public float MannaAmount => _currentManaAmount;

        #endregion
    }
}