using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    [SerializeField] private TimerController timer;
    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
    }

    void Update()
    {
        var minutes = 2 - Mathf.Round(timer.time / 60);
        var seconds = Mathf.Round(60 - timer.time % 60);
        timerText.text = minutes + ":" + seconds;
    }
}
