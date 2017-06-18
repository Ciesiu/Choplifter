using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {

    Animator animator;
    System.Random rnd;

    // Use this for initialization
    void Start () {
        rnd = new System.Random((int)this.transform.position.y);
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //rnd = new System.Random();
        animator.SetInteger("starFactor", rnd.Next(0,4));
	}
}
