using Source.Model;
using Source.Model.Ship;
using Source.Model.Utils;
using Source.Model.Weapon;
using Source.Presenters;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(ShipPresenter))]
    public class ShipController : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private IShipInput _shipInput;
        private ShipMovement _shipMovement;
        private IGun _firstGun;
        private IGun _secondGun;
        private Camera _camera;

        public Vector2 ShootPoint => _shootPoint.position - _camera.transform.position;

        public void Init(IShipInput shipInput, ShipMovement shipMovement, Camera camera)
        {
            _shipInput = shipInput;
            _camera = camera;
            _shipMovement = shipMovement;

            enabled = true;
        }

        private void Update()
        {
            if(_shipMovement.IsNull())
                return;

            if (_shipInput.Move != 0)
            {
                Vector2 moveDirection = _shipMovement.Forward * _shipInput.Move;
                _shipMovement.Accelerate(moveDirection, Time.deltaTime);
            }
            else
            {
                _shipMovement.SlowDown(Time.deltaTime);
            }

            if(_shipInput.Rotate != 0)
                _shipMovement.Rotate(_shipInput.Rotate, Time.deltaTime);
        }

        private void OnEnable()
        {
            if(_shipInput == null)
                return;

            _shipInput.Enable();

            _shipInput.FirstGunShot += OnFirstGunButtonClicked;
            _shipInput.SecondGunShot += OnSecondGunButtonClicked;
        }

        private void OnDisable()
        {
            if (_shipInput == null)
                return;

            _shipInput.Disable();

            _shipInput.FirstGunShot -= OnFirstGunButtonClicked;
            _shipInput.SecondGunShot -= OnSecondGunButtonClicked;
        }

        public void EnableShipControl() =>
            enabled = true;

        public void DisableShipControl() => 
            enabled = false;

        public ShipController BindFirstGun(IGun gun)
        {
            _firstGun = gun;
            return this;
        }

        public ShipController BindSecondGun(IGun gun)
        {
            _secondGun = gun;
            return this;
        }

        public void ResetMovementState() => 
            _shipMovement.ResetSpeed();

        private void OnFirstGunButtonClicked() => 
            _firstGun?.TryShoot(ShootPoint, _shipMovement.Forward);

        private void OnSecondGunButtonClicked() => 
            _secondGun?.TryShoot(ShootPoint, _shipMovement.Forward);
    }
}