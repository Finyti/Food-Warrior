using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class AsyncTimer : MonoBehaviour
{

    public static async Task Delay(float seconds, Action func, bool ignoreTimeScale = false)
    {
        var elapsed = 0f;
        while (elapsed < seconds)
        {
            elapsed += ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
            if (elapsed >= seconds)
            {
                func();
            }
            await Task.Yield();
        }
    }
}

