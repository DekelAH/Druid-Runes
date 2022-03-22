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

        [SerializeField]
        private float _manaToGive;

        [SerializeField]
        private float _giveManaDelay;

        [SerializeField]
        private Text _manaAmountText;
        
        #endregion

        #region Fields

        private float _currentManaAmount;

        // I'm not sure if its the right place to call this method because FulfilManaActivity class isn't MonoBehaviour, i chose to call it here because its mana related
        private readonly FulfilManaActivity _ffma = new FulfilManaActivity();

        #endregion

        #region Methods

        private void Start()
        {
            UpdateManaBar();
            _ffma.BeginManaFulfilment(_giveManaDelay, _manaToGive);
        }

        private void Update()
        {
            InitialBarValue();
            UpdateManaText();
        }
        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.ManaAmountChange -= AddManaAmount;
            playerModel.ManaAmountChange -= TakeManaAmount;
        }

        private void UpdateManaText()
        {
            _manaAmountText.text = $"{_currentManaAmount} / 100";
        }

        private void InitialBarValue()
        {
            var playerModel = SetPlayerModel();
            _currentManaAmount = playerModel.ManaAmount;

            _manaFillImage.fillAmount = _currentManaAmount / 100;
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