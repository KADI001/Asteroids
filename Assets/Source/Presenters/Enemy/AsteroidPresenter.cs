using Source.Model.Enemy;

namespace Source.Presenters.Enemy
{
    public class AsteroidPresenter : EnemyPresenter
    {
        public new Asteroid Model => base.Model as Asteroid;

        protected override void OnCollidedWithBullet()
        {
            Model.FallApart();
            Model.Die();
        }
    }
}