using UnityEngine;
using System.Collections;

public class MissleBehavior : MonoBehaviour {

    public float timer = 3f;
    public GameObject ExplosionPrefab;
    float missileSpeed = 10;
    Quaternion rotation;

    void OnCollisionEnter2D(Collision2D coll)
    {
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        Transform explosion = Instantiate(ExplosionPrefab, transform.position, zero) as Transform;
        Destroy(gameObject);
    }
    

	// Use this for initialization
	void Start () {
        rotation.eulerAngles = new Vector3(0, 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        //Vector3 velocity = new Vector3(0,bulletSpeed * Time.deltaTime , 0);
        Vector3 velocity = new Vector3(missileSpeed * Time.deltaTime * -1, 0, 0);

        pos += rotation * velocity;

        transform.position = pos;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
