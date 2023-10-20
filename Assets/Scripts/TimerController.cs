using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float time;
    public bool isStarted;

    void Start()
    {
        time = 0;
        isStarted = true;
    }

    public void PauseTimer() 
    {
        isStarted = false;
    }

    public void StopTimer()
    {
        isStarted = false;
        time = 0;
    }

    void Update()
    {
        if (isStarted) time += Time.deltaTime;
    }
}
