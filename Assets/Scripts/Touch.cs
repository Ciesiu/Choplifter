using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    private Controls player;

    public GameObject heliBulletPrefab;
    public float fireDelay = 0.15f;
    float cooldownTimer = 0;
    

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
    }

    public void ShootButton()
    {
        if (player.flyingDisabled == false)
        {
            if (cooldownTimer <= 0)
            {
                
                Debug.Log("pew");
                cooldownTimer = fireDelay;
                Quaternion zero = new Quaternion();
                zero.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log(player.transform.position);

                Transform bullet = Instantiate(heliBulletPrefab, player.transform.position, zero) as Transform;
                Physics2D.IgnoreLayerCollision(8, 9);
                Physics2D.IgnoreLayerCollision(11, 9);
                //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            }
        }
    }
    public void LeftArrow()
    {
        if (player.flyingDisabled == false)
        {
            player.moveright = false;
            player.moveleft = true;
            player.animator.SetInteger("HorizontalMovement", 1);
            player.animator.SetFloat("Acceleration", 1);
            player.animator.SetBool("Mirror", false);
            setShootingDirection();
        }
    }
    public void RightArrow()
    {
        if (player.flyingDisabled == false)
        {
            player.moveright = true;
            player.moveleft = false;
            player.animator.SetInteger("HorizontalMovement", 2);
            player.animator.SetFloat("Acceleration", 1);
            player.animator.SetBool("Mirror", false);
            setShootingDirection();
        }
    }
    public void TopArrow()
    {
        player.moveup = true;
        player.movedown = false;
        setShootingDirection();
    }
    public void BottomArrow()
    {
        if (player.flyingDisabled == false)
        {
            player.movedown = true;
            player.moveup = false;
            setShootingDirection();
        }
    }
    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
        player.animator.SetInteger("HorizontalMovement", 0);
        player.animator.SetFloat("Acceleration", -1);
        player.animator.SetBool("Mirror", true);
        player.movespeed = 5;
        setShootingDirection();
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;
        player.animator.SetInteger("HorizontalMovement", 0);
        player.animator.SetFloat("Acceleration", -1);
        player.animator.SetBool("Mirror", true);
        player.movespeed = 5;
        setShootingDirection();
    }
    public void ReleaseTopArrow()
    {
        player.moveup = false;
        setShootingDirection();
    }
    public void ReleaseBottomArrow()
    {
        player.movedown = false;
        setShootingDirection();
    }
    public void SwitchDirectionLeft()
        //lewo - 1, środek - 2, prawo - 3
    {
        if (player.flyingDisabled == false)
        {
            player.direction = player.animator.GetInteger("Direction");
            player.direction--;
            if (player.direction < 1) player.direction = 3;
            player.animator.SetInteger("Direction", player.direction);
            setShootingDirection();
        }
    }
    public void SwitchDirectionRight()
    {
        if (player.flyingDisabled == false)
        {
            player.direction = player.animator.GetInteger("Direction");
            player.direction++;
            if (player.direction > 3) player.direction = 1;
            player.animator.SetInteger("Direction", player.direction);
            setShootingDirection();
        }
    }
    
    void setShootingDirection()
    {
        player.direction = player.animator.GetInteger("Direction");
        if (player.direction == 1)
        {
            if (player.moveleft)
            {
                player.shootingDirection = 3;
            }
            else if (player.moveright)
            {
                player.shootingDirection = 1;
            }
            else
            {
                player.shootingDirection = 2;
            }
        }
        else if(player.direction == 2)
        {
            if (player.moveleft)
            {
                player.shootingDirection = 4;
            }
            else if (player.moveright)
            {
                player.shootingDirection = 6;
            }
            else
            {
                player.shootingDirection = 5;
            }
        }
        else if(player.direction == 3)
        {
            if (player.moveleft)
            {
                player.shootingDirection = 7;
            }
            else if (player.moveright)
            {
                player.shootingDirection = 9;
            }
            else
            {
                player.shootingDirection = 8;
            }
        }
    }
    // Update is called once per frame
    void Update () {
        cooldownTimer -= Time.deltaTime;
	}
}
