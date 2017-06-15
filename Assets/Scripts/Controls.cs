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
