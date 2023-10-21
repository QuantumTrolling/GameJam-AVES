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
    private GameObject[] chosenBears;
    public bool blocked;
    public bool stateIgrushki;
    void Start()
    {
        stateIgrushki = true;
        blocked = false;
        chosenBooks = new GameObject[2];
        chosenBears = new GameObject[3];
        chosenBears[0] = chosenBears[1] = chosenBears[2] = null;
        chosenBooks[0] = chosenBooks[1] = null;
        Cursor.visible = true;
        ui = FindObjectOfType<UiController>();
    }

    bool checkNull(GameObject[] obj)
    {
        bool flag = true;
        foreach (var item in obj)
        {
            if (item == null)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
  
    void Update()
    {
        

        if (GameObject.Find("CanvasIgrushki") != null)
        {
            stateIgrushki = GameObject.Find("CanvasIgrushki").GetComponent<IgrushkiData>().isBlocked;
            var checkSolutionIgrushki = GameObject.Find("CanvasIgrushki").GetComponent<IgrushkiData>();
            if (checkNull(chosenBears))
            {
                if (checkSolutionIgrushki.CheckSolution(chosenBears))
                {
                    ui.makeVisible(1);
                } else
                {
                    chosenBears[0] = chosenBears[1] = chosenBears[2] = null;
                    Debug.Log("Попробуй ещё раз!");
                }
                ui.DisactiveGame("Igrushki");
            }
        }
        

        if (Input.GetMouseButtonDown(0) && !blocked)
        {
            if (CheckCollider() != null)
            {
                Debug.Log(CheckCollider().name);

                if (CheckCollider().tag == "obj")
                {
                    ui.putToInventory(CheckCollider());
                }

                if (CheckCollider().name == "Vnuk" && CheckCollider().GetComponent<VnukData>() != null)
                {
                    CheckCollider().GetComponent<VnukData>().anim.SetTrigger("Knifer");
                    CheckCollider().GetComponent<VnukData>().ChangeState(1);
                } else if (CheckCollider().name == "WardrobeTrigger")
                {

                    CheckCollider().GetComponent<BoxCollider2D>().enabled = false;
                    var soundWardrobe = GameObject.Find("MainSound").GetComponent<Sounds>().sounds[1];
                    GameObject.Find("MainSound").GetComponent<Sounds>().PlaySound(soundWardrobe);
                    ui.ChangeBackState(1);
                    /*
                    if (ui.nowState == 0)
                    {
                        
                    } else
                    {
                        ui.ActiveBook();
                    }
                    */
                }
                if (CheckCollider().name == "Knigi")
                {
                    ui.ActiveGame("Knigi");
                }
                if (CheckCollider().name == "Igrushki")
                {
                    ui.ActiveGame("Igrushki");
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
                    if (GameObject.Find("пластырь") != null)
                    {
                        GameObject.Find("пластырь").GetComponent<SpriteRenderer>().enabled = true;
                        GameObject.Find("пластырь").GetComponent<BoxCollider2D>().enabled = true;
                    }
                    
                    ui.ShowInventory();
                }
                if (CheckCollider().tag == "igrushka" && !stateIgrushki)
                {
                    Debug.Log("Choosen...");
                    for (int i = 0; i < chosenBears.Length; i++)
                    {
                        if (chosenBears[i] == null)
                        {
                            chosenBears[i] = CheckCollider();
                            break;
                        }
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
