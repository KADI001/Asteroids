using System.Collections;
using UnityEngine;

namespace Source
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}