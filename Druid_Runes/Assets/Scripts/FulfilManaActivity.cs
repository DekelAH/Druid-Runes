using Assets.Scripts.Infastructure;
using System.Collections;

namespace Assets.Scripts
{
    public class FulfilManaActivity
    {
        #region Methods

        public void BeginManaFulfilment(float delay, float manaToGive)
        {
            var playerModel = PlayerModelProvider.Instance.GetPlayerModel;
            TimePulseService.PulseEvery(delay, () => playerModel.AddMana(manaToGive));
        }

        #endregion
    }
}
