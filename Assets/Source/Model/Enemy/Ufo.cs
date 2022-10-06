using Source.Model.Pause;
using UnityEngine;

namespace Source.Model.Enemy
{
    public class Ufo : Enemy, IUpdatable, IPauseable
    {
        private const int Award = 10;
        private readonly Transformable _target;
        private bool _isPaused;

        public Ufo(Vector2 position, float velocity, Transformable target) : base(position, 0, velocity)
        {
            _target = target;

            LookAtTarget();
        }

        public bool IsPaused => _isPaused;

        public void Update(float deltaTime)
        {
            if(IsPaused)
                return;

            LookAtTarget();
            FollowTarget(deltaTime);
        }

        private void LookAtTarget() => 
            LookAt(_target.Position);

        private void FollowTarget(float deltaTime) => 
            MoveTo(Vector2.MoveTowards(Position, _target.Position, Velocity * deltaTime));

        private void LookAt(Vector2 target) => 
            Rotate(Vector2.SignedAngle(Forward, (target - Position).normalized));

        public void Pause() => 
            _isPaused = true;

        public void Resume() =>
            _isPaused = false;

        public override int GetAward() => Award;
    }
}