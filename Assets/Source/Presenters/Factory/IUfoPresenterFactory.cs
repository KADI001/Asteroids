using Assets.Source.Model.Enemy;
using Assets.Source.Presenters.Enemy;

namespace Assets.Source.Presenters.Factory
{
    public interface IUfoPresenterFactory
    {
        public UfoPresenter CreateUfo(Ufo ufo);
    }
}