using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Source.Presenters
{
    public class GameEndWindowPresenter : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exitGame;

        private void Awake()
        {
            _restart.onClick.AddListener(OnRestartClicked);
            _exitGame.onClick.AddListener(OnExitGameClicked);
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);

        private void OnExitGameClicked() => 
            Application.Quit();

        private void OnRestartClicked() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
