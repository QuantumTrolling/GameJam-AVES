using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject panel;

    private AudioClip play_sound;
    private Sounds audcontroller;


    private void Start()
    {
        audcontroller = GameObject.Find("MainSound").GetComponent<Sounds>();
        play_sound = audcontroller.sounds[0]; //0 - звук запуска

    }

    public void play()
    {
        audcontroller.PlaySound(play_sound);
        Time.timeScale = 1f;
        panel.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<PointController>().blocked = false;
    }
}
