using UnityEngine;
using System.Collections;

public class BurningHouseDropThePeople : MonoBehaviour {

    int survs;
    private Controls player;
    public GameObject surv;
    System.Random rnd;
    float survRespCooldown = 0.3f;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
        rnd = new System.Random((int)transform.position.x);
        survs = 16;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.activeSurvs < 8)
            if (survs > 0 && survRespCooldown <= 0)
            {
                player.activeSurvs++;
                //zresp surva
                
                Quaternion zero = new Quaternion();
                zero.eulerAngles = new Vector3(0, 0, 0);
                Transform burningHouse = Instantiate(surv, transform.position, zero) as Transform;
                survs--;
                survRespCooldown = 0.3f;
            }
        survRespCooldown -= Time.deltaTime;
	}
}
