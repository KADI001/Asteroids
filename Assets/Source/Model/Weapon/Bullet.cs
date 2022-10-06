using Source.Model.Utils;
using UnityEngine;

namespace Source.Model.Weapon
{
    public abstract class Bullet : Transformable, IUpdatable
    {
        private readonly Timer _timer;
        private readonly float _velocity;

        protected Bullet(Vector2 from, Vector2 to, float velocity, float lifeTimeInSeconds) : base(from, Vector2.SignedAngle(Vector2.up, to))
        {
            _velocity = velocity;
            _timer = new Timer(lifeTimeInSeconds);

            _timer.Start(OnTimerFinished);
        }

        public void Update(float deltaTime)
        {
            Move(Forward * (_velocity * deltaTime));
            _timer.Update(deltaTime);
        }

        private void OnTimerFinished() => 
            Dispose();
    }
}