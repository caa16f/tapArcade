using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{

    public AudioSource song;
    bool firstNote = true;
    void Awake()
    {
       
    }



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (firstNote)
        {
            song.Play();
            firstNote = false;
        }
    }
    }
