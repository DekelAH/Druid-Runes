using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.Rune_Buttons
{
    public class DoubleSqureRuneButton : CastRuneButtonBase
    {
        #region Editor

        [SerializeField]
        private float _healthToAdd;

        [SerializeField]
        private float _manaToAdd;

        #endregion

        #region Methods

        public override void OnClick()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;

            if (!_isDrawing)
            {
                if (playerModel.ManaAmount < _manaCost)
                {
                    Debug.Log("Not Enough Mana!");
                    return;
                }

                playerModel.AddHealth(_healthToAdd);
                playerModel.AddMana(_manaToAdd);
                playerModel.TakeMana(_manaCost);
                _rune.DrawRune();
            }
        }

        #endregion
    }
}
