using UnityEngine;
using System.Collections;

public class NormalSurv : MonoBehaviour {

    Controls player;
    Vector3 movementPerFrame;
    public Animator animator;
    int destroyIn = 2;
    System.Random rnd;
    //bool makeWay = false;
    //int startingFrames;
    //int startingDirection;
    float actionTimer = 0.0f;
    int currentAction;


    // Use this for initialization
    void Start () {
        rnd = new System.Random();
        player = FindObjectOfType<Controls>();
        animator = this.GetComponent<Animator>();
        movementPerFrame = new Vector3(0.05f, 0, 0);
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "heliBullet" || coll.collider.tag == "tankBullet" || coll.collider.tag == "jetMissile")
        {
            gameHolder.SurvDied();
            player.activeSurvs--;
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update () {
        if (player.flyingDisabled && gameHolder.SURV_ONBOARD < 16 && System.Math.Abs(player.transform.position.x - transform.position.x) < 6)
        { //jeśli gracz przyziemiony && miejsca na pokładzie && gracz bliżej niż 6 jednostek
            if (System.Math.Abs(player.transform.position.x - transform.position.x) > 0.5) //jeśli gracz jest dalej niż pół jednostki
            {
                if (player.transform.position.x > transform.position.x)
                {
                    animator.SetInteger("RunDirection", 1); //bieg w prawo
                    animator.SetInteger("GetDownYouMOFO", 0);
                    transform.position += movementPerFrame;
                }
                else
                {
                    animator.SetInteger("RunDirection", 2); //bieg w lewo
                    animator.SetInteger("GetDownYouMOFO", 0);
                    transform.position -= movementPerFrame;
                }
            }
            else //jeśli gracz jest bliżej niż pół jednostki
            {
                if (player.transform.position.x > transform.position.x)
                {
                    animator.SetInteger("RunDirection", 1); //wsiadanie z lewej
                    animator.SetInteger("GetDownYouMOFO", 0);
                    animator.SetInteger("GetToTheChoppah", 1);
                    destroyIn--;
                }
                else
                {
                    animator.SetInteger("RunDirection", 2); //wsiadanie z prawej
                    animator.SetInteger("GetDownYouMOFO", 0);
                    animator.SetInteger("GetToTheChoppah", 1);
                    destroyIn--;
                }
            }
        }
        else
        {
            if (actionTimer <= 0) //jeśli ostatnio wylosowana akcja zakończyła sie
            {
                //losowanie nowej akcji
                currentAction = rnd.Next(1, 4); //1 - bieg w lewo, 2 - machanie, 3 - bieg w prawo
                //losowanie długośći nowej akcji 0.5 - 1.5s
                actionTimer = (rnd.Next(5, 16)) / 10;
            }
              //wykonanie wylosowanej wcześniej akcji
                switch (currentAction)
                {
                    case 1:
                        animator.SetInteger("RunDirection", 2); //bieg w lewo
                        animator.SetInteger("GetDownYouMOFO", 0);
                        transform.position -= movementPerFrame;
                        break;
                    case 2:
                        animator.SetInteger("RunDirection", 1); //bieg w prawo
                        animator.SetInteger("GetDownYouMOFO", 0);
                        transform.position += movementPerFrame;
                        break;
                    case 3:
                        animator.SetInteger("RunDirection", 0);
                        animator.SetInteger("GetDownYouMOFO", 1);
                        break;
                }
                actionTimer -= Time.deltaTime;
            
        }
        //-0.8118472 y na ziemi
        if (destroyIn <= 0)
        {
            gameHolder.SurvOnBoard();
            Destroy(gameObject);
        }
    }
}
