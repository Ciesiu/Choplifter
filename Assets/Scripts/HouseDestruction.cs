using UnityEngine;
using System.Collections;

public class HouseDestruction : MonoBehaviour {

    public GameObject burnHouse;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        Transform burningHouse = Instantiate(burnHouse, transform.position, zero) as Transform;
        Physics2D.IgnoreLayerCollision(8, 13);
        Physics2D.IgnoreLayerCollision(9, 13);
        Destroy(gameObject);
    }
}
