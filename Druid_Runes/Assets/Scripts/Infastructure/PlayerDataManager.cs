using UnityEngine;
using System.IO;
using System;
using Assets.Scripts.Models;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;

        #endregion

        #region Constructors

        private PlayerDataManager()
        {
            SubscribeToEvents();
        }

        #endregion

        #region Methods

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            return playerModel;
        }

        private void OnSaveHealthToPrefs(float health)
        {

        }

        private void OnSaveManaToPrefs(float mana)
        {

        }

        private void SubscribeToEvents()
        {
            var playerModel = SetPlayerModel();
            playerModel.HealthChange += OnSaveHealthToPrefs;
            playerModel.ManaAmountChange += OnSaveManaToPrefs;
        }

        public void SaveToPlayerPrefs()
        {
            var playerModel = SetPlayerModel();
            PlayerPrefs.SetFloat("health", playerModel.HealthAmount);
            PlayerPrefs.SetFloat("mana", playerModel.ManaAmount);
            PlayerPrefs.Save();
            Debug.Log("Saved to PlayerPrefs!");
        }

        public void LoadPlayerPrefs()
        {
            var playerModel = SetPlayerModel();
            playerModel.Initialize(PlayerPrefs.GetFloat("health"), PlayerPrefs.GetFloat("mana"));
            Debug.Log("Loaded from PlayerPrefs!");
        }

        public void SaveToLocalFile()
        {
            var playerModel = SetPlayerModel();
            string json = JsonUtility.ToJson(playerModel);
            File.WriteAllText(Application.dataPath + "/save.txt", json);

            Debug.Log("Saved to LocalFile!");
        }

        public void LoadLocalFile()
        {
            if (File.Exists(Application.dataPath + "/save.txt"))
            {
                string json = File.ReadAllText(Application.dataPath + "/save.txt");
                Debug.Log("Loaded: " + json);

                var playerModel = SetPlayerModel();
                JsonUtility.FromJsonOverwrite(json, playerModel);

                playerModel.Initialize(playerModel.HealthAmount, playerModel.ManaAmount);
            }
        }

        public void CheckSaveModelName()
        {
            var playerModel = SetPlayerModel();

            if (playerModel.ModelName == "PlayerPrefs")
            {
                SaveToPlayerPrefs();
            }
            else
            {
                SaveToLocalFile();
            }
        }

        public void CheckLoadModelName()
        {
            var playerModel = SetPlayerModel();

            if (playerModel.ModelName == "PlayerPrefs")
            {
                LoadPlayerPrefs();
            }
            else
            {
                LoadLocalFile();
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            _instance = new PlayerDataManager();
            Debug.Log("Player Data Manager Created");
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion
    }
}
