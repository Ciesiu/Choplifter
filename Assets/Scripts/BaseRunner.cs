using UnityEngine;
using System.Collections;

public class BaseRunner : MonoBehaviour {

    Controls player;
    Vector3 movementPerFrame;
    public Animator animator;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
        animator = this.GetComponent<Animator>();
        if(transform.position.x > 5)
        {
            animator.SetInteger("whereTo", 0);
            movementPerFrame = new Vector3(-0.05f, 0, 0);
        }
        else
        {
            animator.SetInteger("whereTo", 1);
            movementPerFrame = new Vector3(0.05f, 0, 0);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += movementPerFrame;
        if(transform.position.x < 5.1 && transform.position.x > 4.9)
        {
            gameHolder.SurvSaved();
            Destroy(gameObject);
        }
    }
}
