using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    

    //Make sure you have a camera, it will determine the direction the character faces
    Transform cam;

    public BaseHero baseHero;

    public float speed = 10f;    //How fast the player can move
    public float turnSpeed = 100;    //How fast the player can rotate

    public int noOfClicks; //Determines Which Animation Will Play
    public bool canClick; //Locks ability to click during animation event
    public bool canMove;

    Animator animator;//You may not need an animator, but if so declare it here
    Rigidbody rigidBody;//Make sure you have a rigidbody

    void Start()
    {
        //Initialize appropriate components
        baseHero = GetComponent<BaseHero>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        noOfClicks = 0;
        canClick = true;
        canMove = true;
    }

    //No need for update function right now, physics work better in Fixed Update
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            ComboStarter();
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            //right is shorthand for (1,0,0) or the x value            forward is short for (0,0,1) or the z value 
            Vector3 dir = (cam.right * Input.GetAxis("Horizontal")) + (cam.forward * Input.GetAxis("Vertical"));

            dir.y = 0;//Keeps character upright against slight fluctuations

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                //rotate from this /........to this............../.........at this speed 
                rigidBody.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
                rigidBody.transform.position += transform.forward * Time.deltaTime * speed;
                animator.SetInteger("animation", 10);//Walk or run animation works well here
            }
            else
            {
                Vector3 vel = new Vector3(0, rigidBody.velocity.y, 0);
                rigidBody.velocity = vel;
                animator.SetInteger("animation", 25);//Idle animation works well here
            }
        }
    }
    void ComboStarter()
    {
        if (canClick && baseHero.Stamina.BaseValue >= 15)
        {
            if (noOfClicks == 0)
            {
                baseHero.Stamina.BaseValue -= 15;
                baseHero.setRegen(false);
            }
            noOfClicks++;
        }

        if (noOfClicks == 1)
        {
            animator.SetInteger("animation2", 31);
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk01") && noOfClicks == 1)
        {//If the first animation is still playing and only 1 click has happened, return to idle
            animator.SetInteger("animation2", 26);
            canClick = true;
            noOfClicks = 0;
            canMove = true;
            baseHero.setRegen(true);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk01") && noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo   
            if (baseHero.Stamina.BaseValue >= 20)
            {
                animator.SetInteger("animation2", 33);
                canClick = true;
                baseHero.Stamina.BaseValue -= 20;
            }
            else
            {
                animator.SetInteger("animation2", 26);
                canClick = true;
                noOfClicks = 0;
                canMove = true;
                baseHero.setRegen(true);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk02") && noOfClicks == 2)
        {  //If the second animation is still playing and only 2 clicks have happened, return to idle         
            animator.SetInteger("animation2", 26);
            canClick = true;
            noOfClicks = 0;
            canMove = true;
            baseHero.setRegen(true);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk02") && noOfClicks >= 3)
        {  //If the second animation is still playing and at least 3 clicks have happened, continue the combo  
            if (baseHero.Stamina.BaseValue >= 25)
            {
                animator.SetInteger("animation2", 6);
                canClick = true;
                baseHero.Stamina.BaseValue -= 25;
            }
            else
            {
                animator.SetInteger("animation2", 26);
                canClick = true;
                noOfClicks = 0;
                canMove = true;
                baseHero.setRegen(true);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk011"))
        { //Since this is the third and last animation, return to idle          
            animator.SetInteger("animation2", 26);
            canClick = true;
            noOfClicks = 0;
            canMove = true;
            baseHero.setRegen(true);
        }
    }
}