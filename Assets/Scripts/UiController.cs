using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image back;
    [SerializeField] private Sprite[] back_states;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonLoad(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void ChangeBackState(int state)
    {
        back.sprite = back_states[state];
    }



    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
