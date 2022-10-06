using Source.Model.Score;
using TMPro;
using UnityEngine;

namespace Source.Presenters
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScorePresenter : MonoBehaviour
    {
        private const string ScoreString = "Score: ";

        private TMP_Text _textMesh;

        public Score Score { get; private set; }

        private void Awake() => 
            _textMesh = GetComponent<TMP_Text>();

        private void OnEnable()
        {
            if(Score == null)
                return;

            Score.ValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            if (Score == null)
                return;

            Score.ValueChanged -= OnValueChanged;
        }

        public void Init(Score score)
        {
            Score = score;

            OnValueChanged();

            enabled = true;
        }

        private void OnValueChanged()
        {
            UpdateText(ScoreString + Score.Value);
        }

        public void UpdateText(string text)
        {
            _textMesh.text = text;
        }
    }
}
