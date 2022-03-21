using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string PLAYER_MODEL_NAME = "Player Model";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;

        private readonly PlayerModel _playerModel;

        #endregion

        #region Constructors

        private PlayerModelProvider()
        {
            _playerModel = Resources.Load<PlayerModel>(PLAYER_MODEL_NAME);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider();
                }

                return _instance;
            }
        }

        public PlayerModel GetPlayerModel => _playerModel;

        #endregion
    }
}
