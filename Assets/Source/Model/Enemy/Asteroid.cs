using System;
using Assets.Source.Model.Pause;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Source.Model.Enemy
{
    public class Asteroid : Enemy, IUpdatable, IPauseable
    {
        private const int Award = 5;
        private const int AmountAsteroidsPart = 4;

        private readonly float _velocityOfAsteroidPart;
        private bool _isPaused;

        public event Action<AsteroidPart[]> FellApart;

        public Asteroid(Vector2 position, Vector2 flyDirection, float velocity) : base(position, GetRotation(flyDirection), velocity) => 
            _velocityOfAsteroidPart = velocity * 0.5f;

        public bool IsPaused => _isPaused;

        public void Update(float deltaTime)
        {
            if(IsPaused)
                return;

            Move(Forward * (Velocity * deltaTime));
        }

        public void FallApart()
        {
            AsteroidPart[] asteroidParts = new AsteroidPart[AmountAsteroidsPart];

            for (int i = 0; i < asteroidParts.Length; i++)
            {
                Vector2 direction = Random.insideUnitCircle.normalized;
                Vector2 offset = direction * 0.5f;
                asteroidParts[i] = new AsteroidPart(Position + offset, direction, _velocityOfAsteroidPart);
            }

            FellApart?.Invoke(asteroidParts);
        }

        public void Pause() => 
            _isPaused = true;

        public void Resume() => 
            _isPaused = false;

        public override int GetAward() => Award;

        private static float GetRotation(Vector2 flyDirection) => 
            Vector2.SignedAngle(Vector2.up, flyDirection);
    }
}