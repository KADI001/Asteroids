using UnityEngine;

namespace Assets.Source.Model.Enemy
{
    public class EnemyDestroyer : IUpdatable
    {
        private readonly IEnemiesContainer _enemiesContainer;
        private readonly Vector2 _leftTopBound;
        private readonly Vector2 _rightDownBound;

        private readonly Vector2 _offset;

        public EnemyDestroyer(IEnemiesContainer enemiesContainer, Vector2 offset, Vector2 leftTopBound, Vector2 rightDownBound)
        {
            _enemiesContainer = enemiesContainer;
            _offset = offset;
            _leftTopBound = leftTopBound + new Vector2(-offset.x, offset.y);
            _rightDownBound = rightDownBound + new Vector2(offset.x, -offset.y);
        }

        public void Update(float deltaTime)
        {
            for (var i = 0; i < _enemiesContainer.Enemies.Count; i++)
            {
                Enemy enemy = _enemiesContainer.GetEnemyByIndex(i);
                if (enemy.Position.x < _leftTopBound.x
                    || enemy.Position.x > _rightDownBound.x
                    || enemy.Position.y < _rightDownBound.y
                    || enemy.Position.y > _leftTopBound.y)
                {
                    enemy.Dispose();
                }
            }
        }
    }
}