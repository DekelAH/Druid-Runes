using Assets.Scripts;
using Assets.Scripts.Infastructure;
using Assets.Scripts.Runes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Rune_Buttons
{
    public abstract class CastRuneButtonBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        protected Button _selfButton;

        [SerializeField]
        protected float _manaCost;

        [SerializeField]
        protected RuneBase _rune;

        #endregion

        #region Fields

        protected bool _isDrawing;

        #endregion

        #region Methods

        private void Start()
        {
            RegisterToEvents();
        }

        private void OnDestroy()
        {
            _rune.BeginDraw -= OnBeginDraw;
            _rune.EndDraw -= OnEndDraw;
        }

        public virtual void OnClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;

            if (!_isDrawing)
            {
                if (playerModel.ManaAmount < _manaCost)
                {
                    Debug.Log("Not Enough Mana!");
                    return;
                }

                playerModel.TakeMana(_manaCost);
                _rune.DrawRune();
            }
        }

        private void RegisterToEvents()
        {
            _rune.BeginDraw += OnBeginDraw;
            _rune.EndDraw += OnEndDraw;
        }

        private void OnEndDraw(bool isDrawing)
        {
            _isDrawing = isDrawing;
        }

        private void OnBeginDraw(bool isDrawing)
        {
            _isDrawing = isDrawing;
        }
    }

    #endregion
}

