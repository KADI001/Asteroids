using Assets.Source.Model.Enemy;
using Assets.Source.Presenters;
using Assets.Source.Presenters.Enemy;

namespace Assets.Source.Model.Factory
{
    public interface IAsteroidPresenterFactory
    {
        AsteroidPresenter CreateAsteroid(Asteroid asteroid);
        AsteroidPartPresenter CreateAsteroidPart(AsteroidPart asteroidPart);
        AsteroidPartPresenter[] CreateAsteroidParts(AsteroidPart[] asteroidParts);
    }
}