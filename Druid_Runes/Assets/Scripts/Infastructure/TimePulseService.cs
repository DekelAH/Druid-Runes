using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class TimePulseService
    {
        public static Coroutine PulseEvery(float delay, Action pulseCallback)
        {
            return CoroutineService.Instance.BeginCoroutine(PulseEveryInternal(delay, pulseCallback));
        }

        private static IEnumerator PulseEveryInternal(float delay, Action pulseCallback)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                pulseCallback?.Invoke();
            }
        }
    }
}
