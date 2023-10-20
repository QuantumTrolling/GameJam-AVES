using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{

    
    void Start()
    {
        Cursor.visible = true;
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
                    FindObjectOfType<UiController>().ChangeBackState(1);
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
