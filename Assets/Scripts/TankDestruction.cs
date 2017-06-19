using UnityEngine;
using System.Collections;

public class TankDestruction : MonoBehaviour {

    private Controls player;
    public GameObject tank;

    System.Random rnd;
    

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
        rnd = new System.Random((int)transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollision2D(Collision2D coll)
    {
        if (coll.collider.tag == "tank")
        {
            int dir = rnd.Next(0,2);
            Vector3 newPos;
            if (dir == 0)
            {
                newPos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            }
            else
            {
                newPos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            }
            transform.position = newPos;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.tag == "heliBullet") {
            //zresp nowego czołga
            Quaternion zero = new Quaternion();
            zero.eulerAngles = new Vector3(0, 0, 0);
            int newX;
            if (player.transform.position.x <= -70)
            {
                newX = rnd.Next(-70, -45);
                if (System.Math.Abs(newX - (int)player.transform.position.x)<6)
                {
                    newX += 6;
                }
            }
            else
            {
                newX = rnd.Next(-95, -70);
                if (System.Math.Abs(newX - (int)player.transform.position.x) < 6)
                {
                    newX -= 6;
                }
            }

            Vector3 tankPos = new Vector3(newX, -2.474545f, 0);
            

            Transform enemyTank = Instantiate(tank, tankPos, zero) as Transform;
            //zrespiono
            Destroy(gameObject);
        }
    }
}
