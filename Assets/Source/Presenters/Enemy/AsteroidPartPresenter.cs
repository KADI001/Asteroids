namespace Source.Presenters.Enemy
{
    public class AsteroidPartPresenter : EnemyPresenter
    {
        protected override void OnCollidedWithBullet()
        {
            Model.Die();
        }
    }
}