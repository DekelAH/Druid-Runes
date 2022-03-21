using Assets.Scripts.Infastructure;
using System.Collections;

namespace Assets.Scripts
{
    public class FulfilManaActivity
    {
        #region Methods

        public void Begin()
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            float delay = 3f;
            float manaToGive = 15f;
            TimePulseService.PulseEvery(delay, () => playerModel.AddMana(manaToGive));
        }

        #endregion
    }
}
