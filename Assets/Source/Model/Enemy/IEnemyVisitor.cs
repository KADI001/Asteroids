namespace Source.Model.Enemy
{
    public interface IEnemyVisitor
    {
        public void Visit(Asteroid asteroid);
        public void Visit(AsteroidPart asteroidPart);
        public void Visit(Ufo ufo);
        public void Visit(Enemy enemy);
    }
}