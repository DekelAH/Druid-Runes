using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class CoroutineService : MonoBehaviour
    {
        #region Internal Class

        private class CoroutineStarter : MonoBehaviour { }

        #endregion

        #region Fields

        private static CoroutineService _instance;
        private readonly CoroutineStarter _cs;

        #endregion

        #region Constructor

        private CoroutineService()
        {
            var holderGameObject = new GameObject("CoroutineService");
            Object.DontDestroyOnLoad(holderGameObject);
            _cs = holderGameObject.AddComponent<CoroutineStarter>();
        }

        #endregion

        #region Methods

        public Coroutine BeginCoroutine(IEnumerator coroutine)
        {
            return _cs.StartCoroutine(coroutine);
        }

        public void HaltCoroutine(IEnumerator coroutine)
        {
            _cs.StopCoroutine(coroutine);
        }

        #endregion

        #region Properties

        public static CoroutineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoroutineService();
                }

                return _instance;
            }
        }

        #endregion
    }
}
