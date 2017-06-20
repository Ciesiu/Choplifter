using UnityEngine;
using System.Collections;

public class TankBulletBehavior : MonoBehaviour {

    private float bulletSpeed = 5f;
    Quaternion rotation;
    public GameObject ExplosionPrefab;
    private Animator animator;
    private TankDestruction tank;
    private int direction;
    public Rigidbody2D rb;
    private bool firstFrame = true;

    void OnCollisionEnter2D(Collision2D coll)
    {
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        Transform explosion = Instantiate(ExplosionPrefab, transform.position, zero) as Transform;
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        tank = FindObjectOfType<TankDestruction>();
        

        

    }
	
	// Update is called once per frame
	void Update () {
        if (firstFrame)
        {
            //set pattern
            direction = tank.animator.GetInteger("BarrelPosition");
            switch (direction)
            {
                case -2:
                    rotation.eulerAngles = new Vector3(0, 0, 60);
                    break;
                case -1:
                    rotation.eulerAngles = new Vector3(0, 0, 45);
                    break;
                case 0:
                    rotation.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 1:
                    rotation.eulerAngles = new Vector3(0, 0, -45);
                    break;
                case 2:
                    rotation.eulerAngles = new Vector3(0, 0, -60);
                    break;
            }
            firstFrame = false;
        }
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0,bulletSpeed * Time.deltaTime , 0);
        Vector3 rot = rotation.eulerAngles;
        
        switch (direction)
        {
            case -2:
                rot.z += 2f;
                rotation.eulerAngles = rot;
                break;
            case -1:
                rot.z += 2f;
                rotation.eulerAngles = rot;
                break;
            case 0:
                bulletSpeed -= 0.2f;
                rotation.eulerAngles = rot;
                break;
            case 1:
                rot.z -= 2f;
                rotation.eulerAngles = rot;
                break;
            case 2:
                rot.z -= 2f;
                rotation.eulerAngles = rot;
                break;
        }


        pos += rotation  * velocity;

        transform.position = pos;

        
    }
}
