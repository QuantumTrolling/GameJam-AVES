using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BooksData : MonoBehaviour
{
    private GameObject[] spritesBooks;
    private System.Random random = new System.Random();

    void Smash(GameObject[] mas)
    {
        for (int i = mas.Length - 2; i >= 1; i--)
        {
            int j = random.Next(1, i + 1);
            // �������� �������� data[j] � data[i]
            var temp = mas[j].GetComponent<SpriteRenderer>().sprite;
            mas[j].GetComponent<SpriteRenderer>().sprite = mas[i].GetComponent<SpriteRenderer>().sprite;
            mas[i].GetComponent<SpriteRenderer>().sprite = temp;
        }

    }

    public bool CheckIsSolved()
    {
        var flag = true;
        for (int i = 0; i < spritesBooks.Length; i++)
        {
            var spritename = spritesBooks[i].GetComponent<SpriteRenderer>().sprite.name;
            if (spritename != "books_" + spritesBooks[i].name)
            {
                flag = false;
            }
        }
        return flag;
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
