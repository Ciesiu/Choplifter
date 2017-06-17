using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator animator;
    public float movespeed;
    public bool moveleft;
    public bool moveright;
    public bool moveup;
    public bool movedown;
    public int direction = 1;
    public int shootingDirection = 2;
    //1 - left-top; 2 - left-flat; 3 - left-bottom; 
    //4 - front-left; 5 - front-middle; 6 - front-right; 
    //7 - right-top; 8 - right-flat; 9 - right-bottom

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        if (moveup)
        {
            rb.velocity = new Vector2(rb.velocity.x, movespeed);
        }
        if (movedown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -movespeed);
        }
    }
}
