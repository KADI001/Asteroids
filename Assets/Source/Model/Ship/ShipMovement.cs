using Source.Model.Pause;
using Source.Model.Utils;
using UnityEngine;

namespace Source.Model.Ship
{
    public class ShipMovement : IUpdatable, IPauseable
    {
        public const float AccelerationMagnitude = 5f;
        public const float MaxSpeed = 30f;
        public const float AnglesPerSecond = 180f;

        private readonly Ship _ship;
        private Vector2 _speed;

        private readonly Vector2 _leftTopBound;
        private readonly Vector2 _rightDownBound;
        private bool _isPaused;

        public ShipMovement(Ship ship, Vector2 leftTopBound, Vector2 rightDownBound)
        {
            _ship = ship;
            _leftTopBound = leftTopBound;
            _rightDownBound = rightDownBound;
        }

        public Vector2 Speed
        {
            get => _speed;
            private set => _speed = Vector2.ClampMagnitude(value, MaxSpeed);
        }
        public Vector2 Forward => _ship.Forward;
        public float Rotation => _ship.Rotation;
        public Vector2 Position => _ship.Position;
        public bool IsPaused => _isPaused;

        public void Accelerate(Vector2 direction, float deltaTime) => 
            Speed += direction * (AccelerationMagnitude * deltaTime);

        public void SlowDown(float accumulatedTime) => 
            Speed -= Speed * accumulatedTime;

        public void Rotate(float direction, float deltaTime) => 
            _ship.Rotate(direction, AnglesPerSecond * deltaTime);

        public void Update(float deltaTime)
        {
            _ship.Move(Speed * deltaTime);
            RepeatPosition();
        }

        public void Pause() => 
            _isPaused = true;

        public void Resume() => 
            _isPaused = false;

        public void ResetSpeed() => 
            Speed = Vector2.zero;

        private void RepeatPosition()
        {
            Vector2 repeatedPosition = ExtendedVector2.RepeatInBox(_ship.Position, _leftTopBound, _rightDownBound);
            _ship.MoveTo(repeatedPosition);
        }
    }
}