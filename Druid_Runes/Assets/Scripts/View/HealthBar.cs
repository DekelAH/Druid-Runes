using Assets.Scripts.Infastructure;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class HealthBar : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Image _healthFillImage;

        [SerializeField]
        private Text _healthAmountText;

        #endregion

        #region Fields

        private float _currentHealthAmount;

        #endregion

        #region Methods

        private void Start()
        {
            RegisterToEvents();
        }

        private void Update()
        {
            InitialBarValue();
            UpdateHealthText();
        }

        private void OnDestroy()
        {
            var playerModel = SetPlayerModel();
            playerModel.HealthChange -= AddHealthAmount;
            playerModel.HealthChange -= TakeHealthAmount;
        }

        private void UpdateHealthText()
        {
            _healthAmountText.text = $"{_currentHealthAmount} / 100";
        }

        private void InitialBarValue()
        {
            var playerModel = SetPlayerModel();
            _currentHealthAmount = playerModel.HealthAmount;
            _healthFillImage.fillAmount = playerModel.HealthAmount / 100;
        }

        private void AddHealthAmount(float healthAmount)
        {
            _currentHealthAmount += healthAmount;
        }

        private void TakeHealthAmount(float healthAmount)
        {
            _currentHealthAmount -= healthAmount;
        }

        private void RegisterToEvents()
        {
            var playerModel = SetPlayerModel();
            playerModel.HealthChange += AddHealthAmount;
            playerModel.HealthChange += TakeHealthAmount;
        }

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            return playerModel;
        }

        #endregion
    }
}
