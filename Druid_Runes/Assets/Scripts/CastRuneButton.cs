using Assets.Scripts;
using Assets.Scripts.Infastructure;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class CastRuneButton : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button _selfButton;

        [SerializeField]
        private DruidRunePainter _druidRunePainter;

        [SerializeField]
        private float _manaCost;

        #endregion

        #region Fields

        private readonly FulfilManaActivity _ffma = new FulfilManaActivity();

        #endregion

        #region Methods

        private void Start()
        {
            _ffma.Begin();
        }

        private void Update()
        {
            CheckBtnEnabled();
        }

        public void OnClick()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;

            playerModel.TakeMana(_manaCost);
            _druidRunePainter.DrawRune();

        }

        private void CheckBtnEnabled()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;

            if (playerModel.ManaAmount < _manaCost)
            {
                _selfButton.enabled = false;
            }
            else
            {
                _selfButton.enabled = true;
            }
        }

        #endregion
    }
}