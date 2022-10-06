using System;
using Source.Model.Enemy;

namespace Source.Model.Score
{
    public class ScoreCounter : IDisposable
    {
        public readonly Score Score;
        private readonly IEnemiesContainer _enemiesContainer;

        public ScoreCounter(Score score, IEnemiesContainer enemiesContainer)
        {
            Score = score;
            _enemiesContainer = enemiesContainer;

            OnEnable();
        }

        private void OnEnable() =>
            _enemiesContainer.EnemyRegistered += OnEnemyRegistered;

        private void OnDisable() =>
            _enemiesContainer.EnemyRegistered -= OnEnemyRegistered;

        private void OnEnemyRegistered(Enemy.Enemy enemy) => 
            enemy.Dead += OnEnemyDead;

        private void OnEnemyDead(Enemy.Enemy enemy) => 
            Score.Update(enemy);

        public void Dispose() => 
            OnDisable();
    }
}