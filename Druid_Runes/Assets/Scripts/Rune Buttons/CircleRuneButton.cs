using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.Rune_Buttons
{
    public class CircleRuneButton : CastRuneButtonBase
    {
        #region Editor

        [SerializeField]
        private float _addHealth;

        #endregion

        #region Methods
 
        public override void OnClick()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;

            if (!_isDrawing)
            {
                if (playerModel.ManaAmount < _manaCost)
                {
                    Debug.Log("Not Enough Mana!");
                    return;
                }

                playerModel.AddHealth(_addHealth);
                playerModel.TakeMana(_manaCost);
                _rune.DrawRune();
            }
        }

        #endregion
    }
}
