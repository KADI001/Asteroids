using Source.Model.Weapon;
using UnityEngine;

namespace Source.Model.Factory
{
    public interface IBulletFactory
    {
        public DefaultBullet GetDefaultBullet(Vector2 at, Vector2 direction);
        public LaserBullet GetLaserBullet(Vector2 at, Vector2 direction);
    }
}