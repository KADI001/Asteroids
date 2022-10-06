using System;
using Source.Model.Ship;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source.Presenters
{
    public class GameEndWindowPresenter : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exitGame;
        
        private IShipInput _shipInput;

        private void Awake() =>
            Hide();

        private void OnEnable()
        {
            if(_shipInput == null)
                return;

            _exitGame.onClick.AddListener(OnExitGameClicked);
            _shipInput.Disabled += OnShipInputDisabled;
        }

        private void OnDisable()
        {
            if (_shipInput == null)
                return;

            _exitGame.onClick.RemoveListener(OnExitGameClicked);
            _shipInput.Disabled -= OnShipInputDisabled;
        }

        public void Init(IShipInput shipInput, Action OnRestarted)
        {
            _shipInput = shipInput;

            _restart.onClick.AddListener(() => OnRestarted?.Invoke());
            enabled = true;
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);

        private void OnShipInputDisabled() => 
            Show();

        private void OnExitGameClicked() => 
            Application.Quit();
    }
}
