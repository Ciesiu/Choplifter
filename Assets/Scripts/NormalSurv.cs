using UnityEngine;
using System.Collections;

public class NormalSurv : MonoBehaviour {

    Controls player;
    Vector3 movementPerFrame;
    public Animator animator;
    int destroyIn = 2;
    System.Random rnd;
    bool makeWay = false;


    // Use this for initialization
    void Start () {
        rnd = new System.Random((int)transform.position.x);
        player = FindObjectOfType<Controls>();
        animator = this.GetComponent<Animator>();
        movementPerFrame = new Vector3(0.05f, 0, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("asd");
        if (other.name == "wave_0")
            makeWay = true;
    }

    // Update is called once per frame
    void Update () {
        //-0.8118472 y na ziemi
        if (makeWay)
            //TODO do naprawienia
        {
            int dir = rnd.Next(0, 2);
            if (dir == 0)
            {
                transform.position += movementPerFrame;
            }
            else
            {
                transform.position -= movementPerFrame;
            }
            makeWay = false;
        }
        else
        {
            if (System.Math.Abs(player.transform.position.x - transform.position.x) > 1.5)
            {
                if (player.transform.position.x > transform.position.x)
                {
                    animator.SetInteger("RunDirection", 1);
                    animator.SetInteger("GetDownYouMOFO", 0);
                    transform.position += movementPerFrame;
                }
                else
                {
                    animator.SetInteger("RunDirection", 2);
                    animator.SetInteger("GetDownYouMOFO", 0);
                    transform.position -= movementPerFrame;
                }
            }
            else //jeśli nie jest za daleko
            {

                if (!player.flyingDisabled || gameHolder.SURV_ONBOARD >= 16)
                {
                    animator.SetInteger("RunDirection", 0);
                    animator.SetInteger("GetDownYouMOFO", 1);
                }
                else
                {
                    if (System.Math.Abs(player.transform.position.x - transform.position.x) > 0.5)
                    {
                        if (player.transform.position.x > transform.position.x)
                        {
                            animator.SetInteger("RunDirection", 1);
                            animator.SetInteger("GetDownYouMOFO", 0);
                            transform.position += movementPerFrame;
                        }
                        else
                        {
                            animator.SetInteger("RunDirection", 2);
                            animator.SetInteger("GetDownYouMOFO", 0);
                            transform.position -= movementPerFrame;
                        }
                    }
                    else
                    {

                        if (player.transform.position.x > transform.position.x)
                        {
                            animator.SetInteger("RunDirection", 1);
                            animator.SetInteger("GetDownYouMOFO", 0);
                            animator.SetInteger("GetToTheChoppah", 1);
                            destroyIn--;
                        }
                        else
                        {
                            animator.SetInteger("RunDirection", 2);
                            animator.SetInteger("GetDownYouMOFO", 0);
                            animator.SetInteger("GetToTheChoppah", 1);
                            destroyIn--;
                        }
                    }
                }
            }
        }
        if (destroyIn <= 0)
        {
            gameHolder.SurvOnBoard();
            Destroy(gameObject);
        }
    }
}
