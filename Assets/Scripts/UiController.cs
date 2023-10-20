using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image back;
    [SerializeField] private Sprite[] back_states;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject def;
    [SerializeField] private VideoPlayer vp;
    private bool isClicked;
    public int nowState;

    // Start is called before the first frame update
    void Start()
    {
        nowState = 0;
        
    }

    
    public void OnButtonLoad()
    {
        vp.Prepare();
        vp.loopPointReached += LoadScene;
        play();
    }

    private void play()
    {
        vp.Play();
    }

    private void LoadScene(VideoPlayer source)
    {
        SceneManager.LoadScene("MainStage");
    }
  
    




    public void ChangeBackState(int state)
    {
        nowState = state;
        back.sprite = back_states[state];
    }

    public void ActiveBook()
    {
        def.SetActive(false);
        book.SetActive(true);
    }

    public void BookChanger(GameObject book1, GameObject book2)
    {
        var firstPos = book1.GetComponent<SpriteRenderer>().sprite;
        var secondPos = book2.GetComponent<SpriteRenderer>().sprite;
        book1.GetComponent<SpriteRenderer>().sprite = secondPos;
        book2.GetComponent<SpriteRenderer>().sprite = firstPos;
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked && !vp.isPlaying)
        {
            SceneManager.LoadScene("MainStage");
        }
    }
}
