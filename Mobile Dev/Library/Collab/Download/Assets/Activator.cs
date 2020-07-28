using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

   bool active = false;
    GameObject note;
    private Collider2D noteCollider;
    private Collider2D collider;
    SpriteRenderer sr;
    Color old;
    public bool CreateMode;

    GameObject gm;

    public GameObject newNode;


    public Sprite newSprite;
    public Sprite holder;

    public GameObject sparkle;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        holder = sr.sprite;
        resetScore();
      
    }


    // Start is called before the first frame update
    void Start()
    {
      
        gm = GameObject.Find("GameManager");
        collider = GetComponent<Collider2D>();
        old = sr.color;
     
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && active)
        {
            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);
            print(touchPosition);


            if (noteCollider.OverlapPoint(touchPosition) )
            {
               
                Destroy(note);
                gm.GetComponent<GameManager>().addStreak();
                AddScore();
                StartCoroutine(Pressed());

                GameObject clone = (GameObject)Instantiate(sparkle, new Vector3(transform.localPosition.x + 0.46f, transform.localPosition.y +0.16f, 0), Quaternion.identity);
                clone.transform.localScale = new Vector3(9, 9, 0);
                Destroy(clone, 0.3f);

            }
        } else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                var touchPosition = new Vector2(wp.x, wp.y);

                if (collider.OverlapPoint(touchPosition) && CreateMode)
                {
                Instantiate(newNode, transform.position, Quaternion.identity);
            }else{
            
                if (collider.OverlapPoint(touchPosition))
                {
                    gm.GetComponent<GameManager>().resetStreak();
                    StartCoroutine(Pressed());
                }
            }
          
          
           
        }


     
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "WinNote")
        {
            gm.GetComponent<GameManager>().Win();
        }
       
        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
            
            noteCollider = note.GetComponent<Collider2D>();
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
      //  gm.GetComponent<GameManager>().resetStreak();
    }


    IEnumerator Pressed()
    {
        sr.sprite = newSprite;
        
        //sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.sprite = holder;
    }


    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore());
    }

    void resetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

}
