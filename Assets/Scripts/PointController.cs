using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    private UiController ui;
    
    void Start()
    {
        Cursor.visible = true;
        ui = FindObjectOfType<UiController>();
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckCollider() != null)
            {
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
                if (CheckCollider().tag == "book")
                {
                    var firstBook = CheckCollider();
                    var secondBook = GameObject.Find((Int32.Parse((firstBook.name)) + 1).ToString());
                    if (secondBook != null)
                    {
                        ui.BookChanger(firstBook, secondBook);
                    }
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
