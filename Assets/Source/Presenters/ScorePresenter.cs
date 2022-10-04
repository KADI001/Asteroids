using Assets.Source.Model.Score;
using TMPro;
using UnityEngine;

namespace Assets.Source.Presenters
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScorePresenter : MonoBehaviour
    {
        private const string ScoreString = "Score: ";

        private Score _score;
        private TMP_Text _textMesh;

        public Score Model => _score;

        private void Awake()
        {
            _score = new Score();
            _textMesh = GetComponent<TMP_Text>();
        }

        private void OnEnable() => 
            _score.ValueChanged += OnValueChanged;

        private void OnDisable() => 
            _score.ValueChanged -= OnValueChanged;

        private void OnValueChanged() =>
            _textMesh.text = ScoreString + _score.Value;
    }
}
