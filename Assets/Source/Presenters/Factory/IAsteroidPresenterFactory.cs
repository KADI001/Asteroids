using Source.Presenters.Enemy;
using Source.Model.Enemy;
using UnityEngine;

namespace Source.Presenters.Factory
{
    public interface IAsteroidPresenterFactory
    {
        AsteroidPresenter CreateAsteroid(Asteroid asteroid, Camera camera);
        AsteroidPartPresenter CreateAsteroidPart(AsteroidPart asteroidPart, Camera camera);
        AsteroidPartPresenter[] CreateAsteroidParts(AsteroidPart[] asteroidParts, Camera camera);
    }
}