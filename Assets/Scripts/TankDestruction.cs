using UnityEngine;
using System.Collections;

public class TankDestruction : MonoBehaviour {

    private Controls player;
    public GameObject tank;
    public GameObject tankBullet;
    private Vector3 movePerFrame;
    public Animator animator;

    private float activityTimer = 0;
    private float shootCooldown = 0;
    private int currentActivity = 0;
    private bool lockedInActivity = false;
    private float positionRelativeToPlayer = 0;

    System.Random rnd;
    

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
        animator = GetComponent<Animator>();
        rnd = new System.Random((int)transform.position.x);
        movePerFrame = new Vector3(0.10f,0,0);
    }
	
	// Update is called once per frame
	void Update () {
        //Logika tanków
        //jeśli gracz jest w polu, ale za daleko - deresp
        if(player.transform.position.x < -20)
        {
            if(System.Math.Abs(player.transform.position.x - transform.position.x) > 13)
            {
                respDeresp();
            }
        }

        if (activityTimer <= 0) lockedInActivity = false;
        if (System.Math.Abs(player.transform.position.x - transform.position.x) < 13) //jeśli w pobliżu gracza
        {
            if (System.Math.Abs(player.transform.position.x - transform.position.x) < 2 || lockedInActivity) //jeśli bardzo blisko
            {
                //random activity
                //1 - jazda w lewo 0.5 - 0.7 sekundy
                //2 - jazda w prawo 0.5 - 0.7 sekundy
                //3 - 8 - strzał w gracza z cooldownem 0.5s
                if (activityTimer <= 0) //jeśli nie ma activity to losuj
                {
                    if (shootCooldown <= 0) //można strzelić
                    {
                        currentActivity = rnd.Next(1, 9);
                    }
                    else //nie można strzelić bo cooldown
                    {
                        currentActivity = rnd.Next(1, 3);
                    }
                    if (currentActivity < 3) //jeśli ruch
                    {
                        //activityTimer = (rnd.Next(5, 8)) / 10; //losuj długość ruchu
                        activityTimer = 1.0f;
                    }
                    lockedInActivity = true;
                }
                //wykonaj activity
                switch (currentActivity)
                {
                    case 1:
                        transform.position -= movePerFrame;
                        break;
                    case 2:
                        transform.position += movePerFrame;
                        break;
                    default:
                        //szczał
                        Quaternion zero = new Quaternion();
                        zero.eulerAngles = new Vector3(0, 0, 0);
                        Transform burningHouse = Instantiate(tankBullet, transform.position, zero) as Transform;
                        Physics2D.IgnoreLayerCollision(15, 16);
                        shootCooldown = 0.2f;
                        break;
                }
                if(System.Math.Abs(player.transform.position.x - transform.position.x) > 5) //żeby nie oddalał sie za bardzo
                {
                    activityTimer = 0;
                }

            }
            else
            {//jeśli troche dalej
                if (!lockedInActivity)
                {
                    {
                        //jedź w strone gracza
                        if (player.transform.position.x > transform.position.x)//gracz jest po prawej
                        {
                            //jazda w prawo
                            transform.position += movePerFrame;
                        }
                        else //gracz jest po lewej
                        {
                            //jazda w lewo
                            transform.position -= movePerFrame;
                        }
                    }
                }
            }
        }
        //else lay dormant
        activityTimer -= Time.deltaTime;
        shootCooldown -= Time.deltaTime;
        //ustawianie lufy
        positionRelativeToPlayer = player.transform.position.x - transform.position.x;
        if(positionRelativeToPlayer >= 3.5) //lufa daleko w prawo
        {
            animator.SetInteger("BarrelPosition", 2);
        }else if(positionRelativeToPlayer >= 2) //lufa lekko w prawo
        {
            animator.SetInteger("BarrelPosition", 1);
        }
        else if(positionRelativeToPlayer >= -2) //lufa do góry
        {
            animator.SetInteger("BarrelPosition", 0);
        }
        else if(positionRelativeToPlayer >= -3.5) //lufa lekko w lewo
        {
            animator.SetInteger("BarrelPosition", -1);
        }
        else //lufa daleko w lewo
        {
            animator.SetInteger("BarrelPosition", -2);
        }

    }

    void respDeresp()
    {
        Quaternion zero = new Quaternion();
        zero.eulerAngles = new Vector3(0, 0, 0);
        float newX;
        if (player.transform.position.x <= -85)
        {
            newX = player.transform.position.x + 9.0f + rnd.Next(1, 5);
            //musi z prawej
        }
        else if (player.transform.position.x >= -35)
        {
            newX = player.transform.position.x - 9.0f - rnd.Next(1, 5);
            //musi z lewej
        }
        else
        {
            //random
            int dir = rnd.Next(0, 2);
            if (dir == 0) //po lewej
            {
                newX = player.transform.position.x - 9.0f - rnd.Next(1, 5);
            }
            else // po prawej
            {
                newX = player.transform.position.x + 9.0f + rnd.Next(1, 5);
            }

        }
        Vector3 tankPos = new Vector3(newX, -2.851514f, 0);
        Transform enemyTank = Instantiate(tank, tankPos, zero) as Transform;
        //zrespiono
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.tag == "heliBullet") {
            //-99.5 lewy koniec
            //-20 prawy koniec
            respDeresp();
        }
    }
}
