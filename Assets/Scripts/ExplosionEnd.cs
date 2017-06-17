using UnityEngine;
using System.Collections;

public class ExplosionEnd : MonoBehaviour {


    public float timer = 0.395f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
