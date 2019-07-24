using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    Animator animator;//You may not need an animator, but if so declare it here   
    public BaseHero baseHero;

    public int noOfClicks; //Determines Which Animation Will Play
    public bool canClick; //Locks ability to click during animation event

    void Start()
    {
        //Initialize appropriate components
        animator = GetComponent<Animator>();

        noOfClicks = 0;
        canClick = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { ComboStarter(); }
    }

    void ComboStarter()
    {
        if (canClick)
        {
            noOfClicks++;
        }

        if (noOfClicks == 1 && baseHero.Stamina.BaseValue >= 15)
        {
            animator.SetInteger("animation2", 31);
            baseHero.Stamina.BaseValue -= 15;
        }
        else
        {
            noOfClicks = 0;
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
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk01") && noOfClicks >= 2)
        {//If the first animation is still playing and at least 2 clicks have happened, continue the combo          
            animator.SetInteger("animation2", 33);
            canClick = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk02") && noOfClicks == 2)
        {  //If the second animation is still playing and only 2 clicks have happened, return to idle         
            animator.SetInteger("animation2", 26);
            canClick = true;
            noOfClicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk02") && noOfClicks >= 3)
        {  //If the second animation is still playing and at least 3 clicks have happened, continue the combo         
            animator.SetInteger("animation2", 6);
            canClick = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("atk011"))
        { //Since this is the third and last animation, return to idle          
            animator.SetInteger("animation2", 26);
            canClick = true;
            noOfClicks = 0;
        }
    }
}