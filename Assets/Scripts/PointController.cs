using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    private UiController ui;
    private GameObject[] chosenBooks;

    void Start()
    {
        chosenBooks = new GameObject[2];
        chosenBooks[0] = chosenBooks[1] = null;
        Cursor.visible = true;
        ui = FindObjectOfType<UiController>();
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckCollider() != null)
            {
                Debug.Log(CheckCollider().name);
                if (CheckCollider().name == "Vnuk")
                {
                    CheckCollider().GetComponent<VnukData>().ChangeState(1);
                } else if (CheckCollider().name == "WardrobeTrigger")
                {
                    if (ui.nowState == 0)
                    {
                        ui.ChangeBackState(1);
                    } else
                    {
                        ui.ActiveBook();
                    }
    
                }
                if (CheckCollider().tag == "book" && CheckCollider().name != "0" && CheckCollider().name != "15" && chosenBooks[0] == null)
                {
                    chosenBooks[0] = CheckCollider();
                    chosenBooks[0].GetComponent<SpriteRenderer>().color = Color.red;
                } else if (CheckCollider().tag == "book" && chosenBooks[0] != null && chosenBooks[0] != CheckCollider() && CheckCollider().name != "0" && CheckCollider().name != "15")
                {
                    chosenBooks[1] = CheckCollider();
                    chosenBooks[1].GetComponent<SpriteRenderer>().color = Color.red;
                    ui.BookChanger(chosenBooks[0], chosenBooks[1]);
                    chosenBooks[1].GetComponent<SpriteRenderer>().color = chosenBooks[0].GetComponent<SpriteRenderer>().color = Color.white;
                    chosenBooks[0] = chosenBooks[1] = null;
                    
                } 
                if (CheckCollider().name == "InventoryTrigger")
                {
                    CheckCollider().GetComponent<SpriteRenderer>().enabled = true;
                    ui.ShowInventory();
                }
            }
        } 
    }

    private GameObject CheckCollider()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        } else
        {
            return null;
        }
    }
}
