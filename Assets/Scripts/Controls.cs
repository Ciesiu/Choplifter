using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;
    public float movespeed;
    public bool moveleft;
    public bool moveright;
    public bool moveup;
    public bool movedown;
    public int direction = 1;
    public int shootingDirection = 2;
    public bool flyingDisabled = false;
    public bool decelerate = false;
    //1 - left-top; 2 - left-flat; 3 - left-bottom; 
    //4 - front-left; 5 - front-middle; 6 - front-right; 
    //7 - right-top; 8 - right-flat; 9 - right-bottom

    //AktywneObiekty
    public int activeTanks;
    public int jetTimer;
    public int activeSurvs;   
    

    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "upperGround")
        {
            flyingDisabled = true;
        }
    }

    // Use this for initialization
    void Start () {
        //cam = this.GetComponentInChildren<Camera>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            if (movespeed < 25) movespeed+=0.5f;
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if (movespeed < 25) movespeed+=0.5f;
        }
        if (moveup)
        {
            flyingDisabled = false;
            rb.velocity = new Vector2(rb.velocity.x, movespeed);
        }
        if (movedown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -movespeed);
        }


        if (movespeed >= 15)
        {
            if (moveleft)
            {
                cam.transform.localPosition = new Vector3(-4 * ((movespeed - 15) / 10), 0, -10);
            }
            if (moveright)
            {
                cam.transform.localPosition = new Vector3(4 * ((movespeed - 15) / 10), 0, -10);
            }
        }
        else
        {
            if(cam.transform.localPosition.x > 0)
            {
                if (cam.transform.localPosition.x <= 0.5f) { cam.transform.localPosition = new Vector3(0, 0, -10); }
                else
                {
                    Vector3 localCam = cam.transform.localPosition;
                    localCam.x -= 0.5f;
                    cam.transform.localPosition = localCam;
                }
            }
            else if (cam.transform.localPosition.x < 0)
            {
                if (cam.transform.localPosition.x >= -0.5f) { cam.transform.localPosition = new Vector3(0, 0, -10); }
                else
                {
                    Vector3 localCam = cam.transform.localPosition;
                    localCam.x += 0.5f;
                    cam.transform.localPosition = localCam;
                }
            }
            else cam.transform.localPosition = new Vector3(0, 0, -10);
        }

        Vector3 camPos = cam.transform.position;
        //Debug.Log(camPos);
        cam.transform.position = new Vector3(camPos.x, 0, camPos.z);
    }
    
   
}
