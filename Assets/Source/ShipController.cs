using Assets.Source.Model;
using Assets.Source.Model.Ship;
using Assets.Source.Model.Utils;
using Assets.Source.Model.Weapon;
using Assets.Source.Presenters;
using UnityEngine;

namespace Assets.Source
{
    [RequireComponent(typeof(ShipPresenter))]
    public class ShipController : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private static readonly DIContainer DiContainer = DIContainer.Container;

        private IShipInput _shipInput;
        private ShipMovement _shipMovement;
        private IGun _firstGun;
        private IGun _secondGun;

        private void Awake() => 
            _shipInput = DiContainer.GetSingle<IShipInput>();

        public void Init(ShipMovement shipMovement) => 
            _shipMovement = shipMovement;

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

            _shipMovement?.Update(Time.deltaTime);
        }

        private void OnEnable()
        {
            _shipInput.Enable();

            _shipInput.FirstGunShot += OnFirstGunButtonClicked;
            _shipInput.SecondGunShot += OnSecondGunButtonClicked;
        }

        private void OnDisable()
        {
            _shipInput.Disable();

            _shipInput.FirstGunShot -= OnFirstGunButtonClicked;
            _shipInput.SecondGunShot -= OnSecondGunButtonClicked;
        }

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

        private void OnFirstGunButtonClicked() => 
            _firstGun?.TryShoot(_shootPoint.position, _shipMovement.Forward);

        private void OnSecondGunButtonClicked() => 
            _secondGun?.TryShoot(_shootPoint.position, _shipMovement.Forward);
    }
}