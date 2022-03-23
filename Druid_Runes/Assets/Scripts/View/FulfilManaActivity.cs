using Assets.Scripts.Infastructure;

namespace Assets.Scripts.View
{
    public class FulfilManaActivity
    {
        #region Methods

        public void BeginManaFulfilment(float delay, float manaToGive)
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            TimePulseService.PulseEvery(delay, () => playerModel.AddMana(manaToGive));
        }

        #endregion
    }
}
