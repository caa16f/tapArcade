using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class load_song_scene : MonoBehaviour
{
    [SerializeField] string songTitle; // go to this song

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           // foreach (Touch touch in Input.touches)
            //{
                
                // when menu button is touched
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    SceneManager.LoadScene(songTitle);

                }
          //  }
        }
    }
}
