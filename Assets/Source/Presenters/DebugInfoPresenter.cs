using System;
using Source.Model.Ship;
using Source.Model.Utils;
using Source.Model.Weapon;
using TMPro;
using UnityEngine;

namespace Source.Presenters
{
    public class DebugInfoPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _position;
        [SerializeField] private TMP_Text _rotation;
        [SerializeField] private TMP_Text _speed;
        [SerializeField] private TMP_Text _laserCharges;
        [SerializeField] private TMP_Text _chargeRecovery;

        private ShipMovement _shipMovement;
        private LaserGun _laserGun;

        public void Init(ShipMovement shipMovement, LaserGun laserGun)
        {
            _shipMovement = shipMovement;
            _laserGun = laserGun;
        }

        private void Update()
        {
            if(_shipMovement.IsNull() || _laserGun.IsNull())
                return;

            _position.text = $"Position: {_shipMovement.Position}";
            _rotation.text = $"Rotation: {Mathf.Round(_shipMovement.Rotation)}°";
            _speed.text = $"Speed: {Math.Round(_shipMovement.Speed.magnitude, 1)}km/h";
            _laserCharges.text = $"Laser charges: {_laserGun.Charges}";
            _chargeRecovery.text = $"Charge recovery: {Math.Round(_laserGun.Timer.EndTime - _laserGun.Timer.AccumulatedTime, 1)}";
        }
    }
}
