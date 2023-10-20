using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private Image back;
    [SerializeField] private Sprite[] back_states;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject def;
    public int nowState;

    // Start is called before the first frame update
    void Start()
    {
        nowState = 0;
    }

    public void OnButtonLoad(string scenename)
    {
        SceneManager.LoadScene(scenename);
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
        
    }
}
