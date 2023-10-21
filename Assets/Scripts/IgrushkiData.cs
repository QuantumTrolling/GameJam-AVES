using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IgrushkiData : MonoBehaviour
{

    private GameObject[] Igrushki;
    [SerializeField] private Sprite[] EvilMishki;
    private System.Random random = new System.Random();
    private int[] combination;
    private float GameTimer;
    public bool isBlocked;

    // Start is called before the first frame update
    void Start()
    {
        isBlocked = true;
        GameTimer = 0;
        combination = new int[3];
        for (int i = 0; i < combination.Length; i++)
        {
            combination[i] = random.Next(0, 2);
            Debug.Log(combination[i]);
        }
        Igrushki = GameObject.FindGameObjectsWithTag("igrushka");
        //Array.Reverse(Igrushki);
        
    }

    public bool CheckSolution(GameObject[] chosenBears)
    {
        bool flag = true;
        for (int i = 0; i < chosenBears.Length; i++)
        {
            var intname = Int32.Parse(chosenBears[i].name);
            if (intname != combination[i])
            {
                flag = false;
            } else
            {
                flag = true;
            }
        }
        return flag;
    }

    void changeBear(GameObject bear)
    {
        var num = Int32.Parse(bear.name);
        bear.GetComponent<SpriteRenderer>().sprite = EvilMishki[num]; 
    }

    void returnBear(GameObject bear)
    {
        var num = Int32.Parse(bear.name);
        bear.GetComponent<SpriteRenderer>().sprite = EvilMishki[num + 3];
    }

    void GameLogic()
    {
        var RealTime = Mathf.RoundToInt(GameTimer);
        if (RealTime == 0)
        {
            changeBear(Igrushki[combination[0]]);
        }
        else if (RealTime == 2)
        {
            returnBear(Igrushki[combination[0]]);
            
        } else if (RealTime == 4)
        {
            changeBear(Igrushki[combination[1]]);
        } else if (RealTime == 6)
        {
            returnBear(Igrushki[combination[1]]);
        } else if (RealTime == 8)
        {
            changeBear(Igrushki[combination[2]]);
        } else if (RealTime == 10)
        {
            returnBear(Igrushki[combination[2]]);
            isBlocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer += Time.deltaTime;
        GameLogic();
    }
}
