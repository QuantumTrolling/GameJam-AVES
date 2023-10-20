using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksData : MonoBehaviour
{
    private GameObject[] spritesBooks;
    private System.Random random = new System.Random();

    void Smash(GameObject[] mas)
    {
        for (int i = mas.Length - 1; i >= 1; i--)
        {
            int j = random.Next(1, i + 2);
            // обменять значения data[j] и data[i]
            var temp = mas[j].GetComponent<SpriteRenderer>().sprite;
            mas[j].GetComponent<SpriteRenderer>().sprite = mas[i].GetComponent<SpriteRenderer>().sprite;
            mas[i].GetComponent<SpriteRenderer>().sprite = temp;
        }
        
    }

    void Start()
    {
        spritesBooks = GameObject.FindGameObjectsWithTag("book");
        Smash(spritesBooks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
