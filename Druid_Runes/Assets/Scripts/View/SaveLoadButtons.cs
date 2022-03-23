using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class SaveLoadButtons : MonoBehaviour
    {
        #region Methods

        public void OnSaveButtonClicked()
        {
            var dataManager = PlayerDataManager.Instance;
            dataManager.CheckSaveModelName();
        }

        public void OnLoadButtonClicked()
        {
            var dataManager = PlayerDataManager.Instance;
            dataManager.CheckLoadModelName();
        }

        #endregion
    }
}
