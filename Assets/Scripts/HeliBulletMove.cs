using UnityEngine;
using System.Collections;

public class HeliBulletMove : MonoBehaviour {

    private Controls player;
    float bulletSpeed = 32;
    Quaternion rotation;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Controls>();
        switch (player.shootingDirection)
        {
            case 1:
                rotation.eulerAngles = new Vector3(0, 0, -20);
                break;
            case 2:
                rotation.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 3:
                rotation.eulerAngles = new Vector3(0, 0, 20);
                break;
            case 4:
                rotation.eulerAngles = new Vector3(0, 0, 60);
                bulletSpeed = 10;
                break;
            case 5:
                rotation.eulerAngles = new Vector3(0, 0, 90);
                bulletSpeed = 10;
                break;
            case 6:
                rotation.eulerAngles = new Vector3(0, 0, 120);
                bulletSpeed = 10;
                break;
            case 7:
                rotation.eulerAngles = new Vector3(0, 0, 200);
                break;
            case 8:
                rotation.eulerAngles = new Vector3(0, 0, 180);
                break;
            case 9:
                rotation.eulerAngles = new Vector3(0, 0, 160);
                break;
        }

    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(bulletSpeed * Time.deltaTime * -1, 0, 0);
        
        pos += rotation * velocity;

        transform.position = pos;
	}
}
