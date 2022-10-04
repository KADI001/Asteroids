using UnityEngine;

namespace Assets.Source.Model.Weapon
{
    public class DefaultBullet : Bullet
    {
        public DefaultBullet(Vector2 from, Vector2 to, float velocity, float lifeTimeInSeconds) : base(from, to, velocity, lifeTimeInSeconds)
        {
        }
    }
}