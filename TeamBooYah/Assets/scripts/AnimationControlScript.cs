using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    //This variable below needs a specific character
    // once selected it will select which method to run
    public string characterSelector;
    private Animator animator;
    private string animationState = "AnimationState";
    // horInput and horInput2 are being used to know when you are moving the player in game
    private float horInput;
    private float horInput2;
    // checks whether to go back to idling or not
    public bool returnToNaturalState = true;
    public bool hitState = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Vertical");
        horInput2 = Input.GetAxis("Horizontal");

        switch (characterSelector)
        {
            case "BlueGuy":
                UpdateState();
                break;
            case "GreenGuy":
                UpdateState1();
                break;
            default:
                Debug.Log("Not A Correct Character Selected");
                break;
        }
        
    }

    // animationState is grabbing the parameter and setting it to the value to which animation you want
    private void UpdateState()
    {
        // if hitState is false it will allow the necessary animations to continue
        // if player is hit it will not allow main animations for a calculated time
        if (!hitState)
        {
            if (horInput > 0 || horInput < 0)
            {
                returnToNaturalState = false;
                animator.SetInteger(animationState, 1);
            }else
            {
                returnToNaturalState = true;
            }
            

            if (Input.GetKey(KeyCode.Keypad0))
            {
                returnToNaturalState = false;
                animator.SetInteger(animationState,2);
            }else
            {
                returnToNaturalState = true;
            }
        }

        if(returnToNaturalState && !hitState)
        {
            animator.SetInteger(animationState,0);
        }
    }

    private void UpdateState1(){
        if (!hitState)
        {
            if (horInput2 > 0 || horInput2 < 0)
            {
                returnToNaturalState = false;
                animator.SetInteger(animationState, 1);
            }else
            {
                returnToNaturalState = true;
            }
            

            if (Input.GetKey(KeyCode.F))
            {
                returnToNaturalState = false;
                animator.SetInteger(animationState,2);
            }else
            {
                returnToNaturalState = true;
            }
        }

        if(returnToNaturalState && !hitState)
        {
            animator.SetInteger(animationState,0);
        }
        
    }
}
