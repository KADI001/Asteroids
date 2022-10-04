using System.Collections;
using UnityEngine;

namespace Assets.Source
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}