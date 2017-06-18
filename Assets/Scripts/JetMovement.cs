using UnityEngine;
using System.Collections;
using System;

public class JetMovement : MonoBehaviour {
    public int flaga;
    public bool wPrawo;
    public bool pierwszyRaz;
    public Vector3 ruchPerTick;
    public Animator animator;
    public Collider2D lewy;
    public Collider2D prawy;
    public Collider2D srodkowy;
    public Controls player;

    // Use this for initialization
    void Start () {
        flaga = 1;
        wPrawo = true;
        pierwszyRaz = true;
        ruchPerTick = new Vector3(0.2F, 0, 0);
        animator = GetComponent<Animator>();
        lewy = GetComponent<Collider2D>();
        prawy = GetComponent<Collider2D>();
        player = FindObjectOfType<Controls>();
        srodkowy = GetComponent<Collider2D>();
        this.transform.position = new Vector3(lewy.transform.position.x - 5, player.transform.position.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
            if(wPrawo)
            {
                this.transform.position += ruchPerTick;

            }
            else
            {
                this.transform.position -= ruchPerTick;
            }

	
	}
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(pierwszyRaz)
        {
            if (coll.tag == "MidCollider")
            {
                animator.SetInteger("STATE", 2);
                wPrawo = true;
            }
            if (coll.tag == "LeftCollider")
            {
                animator.SetInteger("STATE", 1);
                wPrawo = true;
            }
            if (coll.tag == "RightCollider")
            {
                animator.SetInteger("STATE", 3);
                wPrawo = false;
                pierwszyRaz = false;
            }

        }
        else
        {
            if (coll.tag == "MidCollider")
            {
                wPrawo = false;
                //szczau
            }
            if (coll.tag == "LeftCollider")
            {
                animator.SetInteger("STATE", 1);
                Destroy(this.gameObject);
            }
        }

    }

}
