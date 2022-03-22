using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.Rune_Buttons
{
    public class TriangleRuneButton : CastRuneButtonBase
    {
        #region Editor

        [SerializeField]
        private float _takeHealth;

        #endregion

        #region Methods

        public override void OnClick()
        {
            base.OnClick();
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            playerModel.TakeHealth(_takeHealth);
        }

        #endregion
    }
}
