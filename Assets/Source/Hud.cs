using Source.Model.Score;
using Source.Model.Ship;
using Source.Model.Weapon;
using Source.Presenters;
using UnityEngine;

namespace Source.Presenters
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private DebugInfoPresenter _debugInfo;
        [SerializeField] private ScorePresenter _scorePresenter;

        public void Init(ShipMovement shipMovement, LaserGun laserGun, Score score)
        {
            _debugInfo.Init(shipMovement, laserGun);
            _scorePresenter.Init(score);
        }

        public void ResetScore()
        {
            _scorePresenter.UpdateText("0");
        }
    }
}
