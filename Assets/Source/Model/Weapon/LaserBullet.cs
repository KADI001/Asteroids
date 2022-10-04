using UnityEngine;

namespace Assets.Source.Model.Weapon
{
    public class LaserBullet : Bullet
    {
        public LaserBullet(Vector2 from, Vector2 to, float lifeTimeInSeconds) : base(from, to, 0, lifeTimeInSeconds)
        {
        }
    }
}