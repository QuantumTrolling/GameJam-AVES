using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    private AudioClip pause_sound;
    private Sounds audcontroller;

    private void Start()
    {
        audcontroller = GameObject.Find("MainSound").GetComponent<Sounds>();
        pause_sound = audcontroller.sounds[0]; //0 - звук паузы
        
    }

    public void pause()
    {
        audcontroller.PlaySound(pause_sound);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PointController>().blocked = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
