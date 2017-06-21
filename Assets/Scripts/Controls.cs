using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    //-99.5 lewy koniec
    //-20 prawy koniec (safeZone/baza za płotkiem)

    public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject explosion;
    public float movespeed;
    public bool moveleft;
    public bool moveright;
    public bool moveup;
    public bool movedown;
    public int direction = 1;
    public int shootingDirection = 2;
    public bool flyingDisabled = false;
    public bool decelerate = false;
    public bool isDead = false;
    private System.Random rnd = new System.Random();



    //1 - left-top; 2 - left-flat; 3 - left-bottom; 
    //4 - front-left; 5 - front-middle; 6 - front-right; 
    //7 - right-top; 8 - right-flat; 9 - right-bottom

    private Vector3 startingPosition = new Vector3(1.780549f, -2.041963f,0);

    public float survUnloadTimer = 0;

    public GameObject tank;
    public GameObject jet;
    public GameObject survToBase;

    public GameObject fence1;
    public GameObject fence2;
    public GameObject fence3;
    public GameObject fence4;

    public GameObject mountaint1;
    public GameObject mountaint2;
    public GameObject mountaint3;

    public AudioSource audio;



    //AktywneObiekty
    public float jetTimer;
    public int activeSurvs = 0;

    private int toHeliResp = -1;
    
  
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "build_helipad_0")
        {
            if (flyingDisabled && gameHolder.SURV_ONBOARD>0)
            {
                if (survUnloadTimer <= 0)
                {   //wypuść typka
                    Quaternion zero = new Quaternion();
                    zero.eulerAngles = new Vector3(0, 0, 0);
                    Transform burningHouse = Instantiate(survToBase, transform.position, zero) as Transform;
                    gameHolder.SURV_ONBOARD--;
                    survUnloadTimer = 0.3f;
                    activeSurvs--;

                }
            }
        }
        survUnloadTimer -= Time.deltaTime;
    }
    

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "upperGround")
        {
            flyingDisabled = true;
        }
        if(coll.gameObject.tag == "jetMissile")
        {
            if (!isDead) { if (gameHolder.ROUND_NUMBER == 3) { gameHolder.ROUND_NUMBER = 4; UITextBehavior.ResetTime(); } toHeliResp = 120; isDead = true; }

            //ded
        }
        if(coll.gameObject.tag == "tankBullet" && flyingDisabled)
        {

            if (!isDead) {if (gameHolder.ROUND_NUMBER == 3) { gameHolder.ROUND_NUMBER = 4; UITextBehavior.ResetTime(); } toHeliResp = 120; isDead = true; }
            //also ded
        }
    }

    // Use this for initialization
    void Start () {


        fence1 = GameObject.Find("env_fence");
        fence2 = GameObject.Find("env_fence (1)");
        fence3 = GameObject.Find("env_fence (2)");
        fence4 = GameObject.Find("env_fence (3)");

        mountaint1 = GameObject.Find("env_mountain");
        mountaint2 = GameObject.Find("env_mountain (1)");
        mountaint3 = GameObject.Find("env_mountain (2)");

        audio = this.GetComponent<AudioSource>();

        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        //tank jest zawsze 1, jak ginie to respi kolejnego
        //jak oddalimy sie za bardzo to sie derespi i respi bliżej
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        Vector3 tank1pos = new Vector3(-57, -2.474545f,0);

        Transform tank0 = Instantiate(tank, tank1pos, zero) as Transform;
        //koniec respienia tanka
        gameHolder.NewGame();
        UITextBehavior.ResetTime();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead) audio.volume = 0.0F;
        else if (flyingDisabled)
        {
            audio.volume = 0.6F;
        }
        else
        {
            audio.volume = 1F;
        }

        if((gameHolder.ROUND_NUMBER!=5)&&(gameHolder.SURV_DIED + gameHolder.SURV_SAVED >= 64))
        {
            gameHolder.ROUND_NUMBER = 5;
            UITextBehavior.ResetTime();
        }

        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            if (movespeed < 15) movespeed+=0.5f;
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if (movespeed < 15) movespeed+=0.5f;
        }
        if (moveup)
        {
            flyingDisabled = false;
            rb.velocity = new Vector2(rb.velocity.x, movespeed);
        }
        if (movedown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -movespeed);
        }


        if (movespeed > 5)
        {
            if (moveleft)
            {
                cam.transform.localPosition = new Vector3(-4 * ((movespeed - 5) / 10), 0, -10);
            }
            if (moveright)
            {
                cam.transform.localPosition = new Vector3(4 * ((movespeed - 5) / 10), 0, -10);
            }
        }
        else
        {
            if(cam.transform.localPosition.x > 0)
            {
                if (cam.transform.localPosition.x <= 0.5f) { cam.transform.localPosition = new Vector3(0, 0, -10); }
                else
                {
                    Vector3 localCam = cam.transform.localPosition;
                    localCam.x -= 0.5f;
                    cam.transform.localPosition = localCam;
                }
            }
            else if (cam.transform.localPosition.x < 0)
            {
                if (cam.transform.localPosition.x >= -0.5f) { cam.transform.localPosition = new Vector3(0, 0, -10); }
                else
                {
                    Vector3 localCam = cam.transform.localPosition;
                    localCam.x += 0.5f;
                    cam.transform.localPosition = localCam;
                }
            }
            else cam.transform.localPosition = new Vector3(0, 0, -10);
        }

        Vector3 camPos = cam.transform.position;
        cam.transform.position = new Vector3(camPos.x, 0, camPos.z);

        //respienie przeciwników
        //respienie dżetów
        jetTimer -= Time.deltaTime;
        if(gameHolder.SURV_SAVED > 8)
        {
            if (jetTimer <= 0 && transform.position.x < -30) //jeśli czas na jeta + gracz jest poza safeZonem
            {
                //resp atak dżeta
                Quaternion zero = new Quaternion();
                zero.eulerAngles = new Vector3(0, 0, 0);
                Transform burningHouse = Instantiate(jet, transform.position, zero) as Transform;
                //zrespiony
                if (gameHolder.SURV_SAVED >= 32)
                {
                    jetTimer = 10f;
                }
                else if (gameHolder.SURV_SAVED >= 16)
                {
                    jetTimer = 20f;
                }
                else
                {
                    jetTimer = 40f;
                }
            }
        }
        //koniec dżetów


        toHeliResp--;
        if (toHeliResp > 0)
        { //animacja śmierci
            rb.velocity = new Vector2(rb.velocity.x, -movespeed);
            if(toHeliResp % 20 == 0)
            {
                //eksplozja
                float expX = transform.position.x - 1f + ((float)rnd.Next(0, 20) / 10);
                Quaternion zero = new Quaternion();
                zero.eulerAngles = new Vector3(0, 0, 0);
                Instantiate(explosion, new Vector3(expX, transform.position.y, transform.position.z), zero);
            }

        }
        if (toHeliResp == 0)
        {
            transform.position = startingPosition;
            flyingDisabled = true;


            if (gameHolder.ROUND_NUMBER < 4)
            {
                
                activeSurvs -= gameHolder.SURV_ONBOARD;
                gameHolder.HeliCrashed();
                UITextBehavior.ResetTime();
            }
            else
            {
                Application.LoadLevel(0);
            }
            animator.SetInteger("Direction", 3);
            isDead = false;
            toHeliResp = -1;
            
        }

        //update płotu
        float camDrift = -20 - cam.transform.position.x;
        //*1
        //*1.1
        //*1.5
        //*2.1
        fence1.transform.localPosition = new Vector3(camDrift, -2.26f, fence1.transform.localPosition.z);
        fence2.transform.localPosition = new Vector3(camDrift * 1.1f, -2.39f, fence2.transform.localPosition.z);
        fence3.transform.localPosition = new Vector3(camDrift * 1.5f, -2.66f, fence3.transform.localPosition.z);
        fence4.transform.localPosition = new Vector3(camDrift * 2.1f, -3.12f, fence4.transform.localPosition.z);

        //koniec updatu płotu
        //update gór
        //-2.169f wysokość osadzenia gór
        float camDrift1 = 11 - cam.transform.position.x;
        float camDrift2 = -14 - cam.transform.position.x;
        float camDrift3 = -32 - cam.transform.position.x;

        mountaint1.transform.localPosition = new Vector3(camDrift1 * 0.5f, -2.169f, mountaint1.transform.localPosition.z);
        mountaint2.transform.localPosition = new Vector3(camDrift2 * 0.5f, -2.169f, mountaint2.transform.localPosition.z);
        mountaint3.transform.localPosition = new Vector3(camDrift3 * 0.5f, -2.169f, mountaint3.transform.localPosition.z);
    }


}
