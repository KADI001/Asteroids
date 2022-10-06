using UnityEngine;

namespace Source.Model.Enemy
{
    public class AsteroidPart : Asteroid
    {
        private const int Award = 2;

        public AsteroidPart(Vector2 position, Vector2 flyDirection, float velocity) : base(position, flyDirection, velocity)
        {
        }

        public override int GetAward() => Award;
    }
}