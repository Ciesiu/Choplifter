using UnityEngine;
using System.Collections;

public class SetActive : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("isActive", true);
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
        }
    }
}
