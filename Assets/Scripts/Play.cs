using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject panel;

    public void play()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
