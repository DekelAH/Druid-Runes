using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Save Config", fileName = "Save Selector")]
    public class SaveSelector : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private SaveType _saveType;

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Methods

        public PlayerModel GetSaveOption()
        {
            switch (_saveType)
            {
                case SaveType.PlayerPrefs:
                    _playerModel.SetModelName("PlayerPrefs");
                    return _playerModel;
                case SaveType.LocalFile:
                    _playerModel.SetModelName("LocalFile");
                    return _playerModel;
                default:
                    return null;
            }
        }

        #endregion
    }
}
