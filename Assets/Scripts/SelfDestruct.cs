using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public float timer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
