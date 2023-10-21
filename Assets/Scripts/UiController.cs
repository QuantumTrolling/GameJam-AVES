using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Unity.VisualScripting;
using System.Net.WebSockets;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image back;
    [SerializeField] private Sprite[] back_states;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject igrushki;
    [SerializeField] private GameObject def;
    [SerializeField] private VideoPlayer vp;
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private GameObject[] hiddenObjects;
    private bool isClicked;
    public int nowState;

    private AudioClip play_sound;
    private AudioClip book_sound;
    private Sounds audcontroller;


    void Start()
    {
        nowState = 0;

        audcontroller = GameObject.Find("MainSound").GetComponent<Sounds>();
        play_sound = audcontroller.sounds[0]; //0 - звук запуска
        book_sound = audcontroller.sounds[3];

    }

    public void makeVisible(int num)
    {
        hiddenObjects[num].SetActive(true);
    }
    
    public void OnButtonLoad()
    {
        audcontroller.PlaySound(play_sound);
        vp.Prepare();
        vp.loopPointReached += LoadScene;
        play();
    }

    public void ShowInventory()
    {
        inventoryCanvas.enabled = true;
    }

    public bool CheckInventoryState()
    {
        return inventoryCanvas.enabled;
    }

   
    private void play()
    {
        vp.Play();
    }

    private void LoadScene(VideoPlayer source)
    {
        SceneManager.LoadScene("MainStage");
    }
  
    public void putToInventory(GameObject subj)
    {
        var slots = GameObject.FindGameObjectsWithTag("slot");
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[slots.Length-i-1].GetComponent<Image>().sprite == null)
            {
                slots[slots.Length-i-1].GetComponent<Image>().sprite = subj.GetComponent<SpriteRenderer>().sprite;
                Destroy(subj);
                return;
            }
        }
       
    }




    public void ChangeBackState(int state)
    {
        nowState = state;
        back.sprite = back_states[state];
    }

    public void ActiveGame(string game)
    {
        def.SetActive(false);
        switch(game)
        {
            case "Knigi":
                book.SetActive(true);
                break;
            case "Igrushki":
                igrushki.SetActive(true);
                break;
        }
        
    }

    public void DisactiveGame(string game)
    {
        def.SetActive(true);
        switch (game)
        {
            case "Knigi":
                book.SetActive(false);
                break;
            case "Igrushki":
                igrushki.SetActive(false);
                break;
        }
    }

    public void CloseInventory()
    {
        inventoryCanvas.enabled = false;
        GameObject.Find("InventoryTrigger").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void BookChanger(GameObject book1, GameObject book2)
    {
        audcontroller.PlaySound(book_sound);
        var firstPos = book1.GetComponent<SpriteRenderer>().sprite;
        var secondPos = book2.GetComponent<SpriteRenderer>().sprite;
        book1.GetComponent<SpriteRenderer>().sprite = secondPos;
        book2.GetComponent<SpriteRenderer>().sprite = firstPos;
        var Canvaser = GameObject.Find("CanvasBook");
        if (Canvaser != null)
        {
            if (Canvaser.GetComponent<BooksData>().CheckIsSolved())
            {
                DisactiveGame("Knigi");
                hiddenObjects[0].SetActive(true);
            }
        }
    }

    public void Exit()
    {
        audcontroller.PlaySound(play_sound);
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
