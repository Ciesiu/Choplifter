using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    private Controls player;
    private int direction = 1;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Controls>();
    }

    public void LeftArrow()
    {
        player.moveright = false;
        player.moveleft = true;
        player.animator.SetInteger("HorizontalMovement", 1);
        player.animator.SetFloat("Acceleration", 1);
        player.animator.SetBool("Mirror", false);
    }
    public void RightArrow()
    {
        player.moveright = true;
        player.moveleft = false;
        player.animator.SetInteger("HorizontalMovement", 2);
        player.animator.SetFloat("Acceleration", 1);
        player.animator.SetBool("Mirror", false);
    }
    public void TopArrow()
    {
        player.moveup = true;
        player.movedown = false;
    }
    public void BottomArrow()
    {
        player.movedown = true;
        player.moveup = false;
    }
    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
        player.animator.SetInteger("HorizontalMovement", 0);
        player.animator.SetFloat("Acceleration", -1);
        player.animator.SetBool("Mirror", true);
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;
        player.animator.SetInteger("HorizontalMovement", 0);
        player.animator.SetFloat("Acceleration", -1);
        player.animator.SetBool("Mirror", true);
    }
    public void ReleaseTopArrow()
    {
        player.moveup = false;
    }
    public void ReleaseBottomArrow()
    {
        player.movedown = false;
    }
    public void SwitchDirectionLeft()
        //lewo - 1, środek - 2, prawo - 3
    {
        direction = player.animator.GetInteger("Direction");
        direction--;
        if (direction < 1) direction = 3;
        player.animator.SetInteger("Direction", direction);
    }
    public void SwitchDirectionRight()
    {
        direction = player.animator.GetInteger("Direction");
        direction++;
        if (direction > 3) direction = 1;
        player.animator.SetInteger("Direction", direction);
    }
    

    // Update is called once per frame
    void Update () {
	
	}
}
