using System;

namespace Assets.Source.Model.Score
{
    public class Score : IScore
    {
        public Score() { }

        public event Action ValueChanged;

        public int Value { get; private set; }

        public void Update(Enemy.Enemy enemy)
        {
            Value += enemy.GetAward();
            ValueChanged?.Invoke();
        }
    }
}
