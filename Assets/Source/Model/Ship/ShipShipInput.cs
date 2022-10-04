using System;
using UnityEngine.InputSystem;

namespace Assets.Source.Model.Ship
{
    public class ShipShipInput : IShipInput, IDisposable
    {
        private readonly UnityShipInput _input;

        public event Action FirstGunShot;
        public event Action SecondGunShot;
        public event Action Enabled;
        public event Action Disabled;

        public ShipShipInput() => 
            _input = new UnityShipInput();

        public float Move => _input.Ship.Move.ReadValue<float>();
        public float Rotate => _input.Ship.Rotate.ReadValue<float>();

        public void Enable() 
        {
            OnEnable();
            Enabled?.Invoke();
        }

        public void Disable()
        {
            OnDisable();
            Disabled?.Invoke();
        }
        
        public void Dispose()
        {
            OnDisable();
            _input?.Dispose();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Ship.FirstGunShoot.performed += OnFirstGunPerformed;
            _input.Ship.SecondGunShoot.performed += OnSecondGunPerformed;
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Ship.FirstGunShoot.performed -= OnFirstGunPerformed;
            _input.Ship.SecondGunShoot.performed -= OnSecondGunPerformed;
        }

        private void OnSecondGunPerformed(InputAction.CallbackContext obj) => 
            FirstGunShot?.Invoke();

        private void OnFirstGunPerformed(InputAction.CallbackContext obj) => 
            SecondGunShot?.Invoke();
    }
}