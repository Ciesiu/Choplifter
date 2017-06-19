using UnityEngine;
using System.Collections;

public class BurgingHouseDropThePeople : MonoBehaviour {

    int survs;
    private Controls player;
    public GameObject surv;
    System.Random rnd;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
        rnd = new System.Random((int)transform.position.x);
        survs = 16;
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.activeSurvs<8)
            if (survs > 0)
            {
                player.activeSurvs++;
                //zresp surva
                float addX = (rnd.Next(0, 101))/100;
                Vector3 newPos = new Vector3(transform.position.x - 0.5f + addX, transform.position.y, transform.position.z);
                Quaternion zero = new Quaternion();
                zero.eulerAngles = new Vector3(0, 0, 0);
                Transform burningHouse = Instantiate(surv, newPos, zero) as Transform;
                survs--;
            }
	}
}
