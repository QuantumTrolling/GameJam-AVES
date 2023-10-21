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
    [SerializeField] private GameObject def;
    [SerializeField] private VideoPlayer vp;
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private GameObject[] hiddenObjects;
    private bool isClicked;
    public int nowState;

    // Start is called before the first frame update
    void Start()
    {
        nowState = 0;
        
    }

    
    public void OnButtonLoad()
    {
       // PLaySound(sounds[0]);
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

    public void ActiveBook()
    {
        def.SetActive(false);
        book.SetActive(true);
    }

    public void DisactiveBook()
    {
        def.SetActive(true);
        GameObject.Find("WardrobeTrigger").GetComponent<BoxCollider2D>().enabled = false;
        book.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryCanvas.enabled = false;
        GameObject.Find("InventoryTrigger").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void BookChanger(GameObject book1, GameObject book2)
    {
        var firstPos = book1.GetComponent<SpriteRenderer>().sprite;
        var secondPos = book2.GetComponent<SpriteRenderer>().sprite;
        book1.GetComponent<SpriteRenderer>().sprite = secondPos;
        book2.GetComponent<SpriteRenderer>().sprite = firstPos;
        var Canvaser = GameObject.Find("CanvasBook");
        if (Canvaser != null)
        {
            if (Canvaser.GetComponent<BooksData>().CheckIsSolved())
            {
                DisactiveBook();
                hiddenObjects[0].SetActive(true);
            }
        }
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
