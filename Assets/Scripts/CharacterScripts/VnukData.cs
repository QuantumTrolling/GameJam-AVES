using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VnukData : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] private Sprite[] states;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeState(int state)
    {
        sr.sprite = states[state];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
