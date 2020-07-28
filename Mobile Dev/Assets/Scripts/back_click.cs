using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class back_click : MonoBehaviour
{


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

          //  foreach (Touch touch in Input.touches)
          //  {
               
                // when menu button is touched

                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                var touchPosition = new Vector2(wp.x, wp.y);

                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }



          //  }
        }
      
            }
            
        }
        
    

