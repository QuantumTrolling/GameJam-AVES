using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    [SerializeField] private TimerController timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject Lost;
    
    
    

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
        if (timer.time >= 180)
        {
            Lost.SetActive(true);
            timer.StopTimer();
        }
        float minutes = 2 - Mathf.FloorToInt(timer.time / 60);
        float seconds = 60 - Mathf.FloorToInt(timer.time % 60);
        timerText.text = minutes + ":" + seconds;
    }
}
