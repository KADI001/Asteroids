using Assets.Source.Presenters;
using Assets.Source.Presenters.Factory;

namespace Assets.Source.Model.Factory
{
    public interface IEnemyPresenterFactory : IAsteroidPresenterFactory, IUfoPresenterFactory
    {
    }
}