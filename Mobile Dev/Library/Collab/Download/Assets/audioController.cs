using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{

    AudioSource song;

    void Awake()
    {
        song = GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        controlSongTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void controlSongTime()
    {
        song.PlayDelayed(4.0f);
    }
}
