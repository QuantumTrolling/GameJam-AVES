using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    [SerializeField] private TimerController timer;
    [SerializeField] private TextMeshProUGUI timerText;

    private AudioClip main_sound;
    private Sounds audcontroller;

    void Start()
    {
        audcontroller = GameObject.Find("MainSound").GetComponent<Sounds>();
        main_sound = audcontroller.sounds[2]; //2 - background

        audcontroller.PlaySound(main_sound, 0.5f);
    }

    void Update()
    {
        var minutes = 2 - Mathf.Round(timer.time / 60);
        var seconds = Mathf.Round(60 - timer.time % 60);
        timerText.text = minutes + ":" + seconds;
    }
}
