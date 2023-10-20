using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    [SerializeField] private TimerController timer;

    void Start()
    {
    }

    void Update()
    {
        Debug.Log(timer.time);
    }
}
