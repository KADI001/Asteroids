using Assets.Source.Model.Weapon;
using UnityEngine;

namespace Assets.Source.Model.Factory
{
    public sealed class GameFactory : IGameFactory
    {
        public DefaultBullet GetDefaultBullet(Vector2 at, Vector2 direction) => 
            new DefaultBullet(at, direction, 25f, 5f);

        public LaserBullet GetLaserBullet(Vector2 at, Vector2 direction) => 
            new LaserBullet(at, direction, 0.1f);
    }
}