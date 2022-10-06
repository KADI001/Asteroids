using Source.Model.Enemy;
using Source.Presenters.Enemy;
using UnityEngine;

namespace Source.Presenters.Factory
{
    public interface IUfoPresenterFactory
    {
        public UfoPresenter CreateUfo(Ufo ufo, Camera camera);
    }
}