using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public float timer = 3f;

    public GameObject ExplosionPrefab;

    void OnCollisionEnter2D(Collision2D coll)
    {
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        Transform explosion = Instantiate(ExplosionPrefab, transform.position, zero) as Transform;
        Destroy(gameObject);
    }

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
