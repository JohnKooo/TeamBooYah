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
        if (horInput > 0 || horInput < 0)
        {
            animator.SetInteger(animationState, 1);
        }
        else{
            animator.SetInteger(animationState,0);
        }

        if (Input.GetKey(KeyCode.Keypad0))
        {
            animator.SetInteger(animationState,2);
        }
    }

    private void UpdateState1(){
        if (horInput2 > 0 || horInput2 < 0)
        {
            animator.SetInteger(animationState, 1);
        }
        else{
            animator.SetInteger(animationState,0);
        }

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetInteger(animationState,2);
        }
    }
}
