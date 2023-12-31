using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float xRange;
    public float yRangeMax;
    public float yRangeMin;
    public float speed = 10;
    public float jumpHeight = 50f;
    public float playerHp = 200;
    public float maxHp = 200;
    private float horizontalInput;
    public Rigidbody charRig;
    public BoxCollider test;
    public GameObject arm;
    public GameObject menu;
    [SerializeField]private Animator animator;
    private string animationState = "AnimationState";
    [SerializeField] AnimationControlScript animationControlScript;
    [SerializeField] HealthBar healthBar;

    private void Awake()
    {
        animationControlScript = GetComponentInChildren<AnimationControlScript>();
        animator = GetComponentInChildren<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    void Start()
    {
        
        playerHp = maxHp;
        healthBar.UpdateHealthBar(playerHp,maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);

        JumpCharacter();
        KeepInBounds();
        DestroyCharacter();
        PunchAttack();
    }

    private void PunchAttack()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            arm.transform.position = new Vector3(transform.position.x + -1,transform.position.y + .55f ,transform.position.z);
        }else
        {
            arm.transform.position = transform.position;
        }
    }

    private void DestroyCharacter()
    {
        if (playerHp <= 0)
        {
            Destroy(gameObject);
            menu.SetActive(true);
        }
    }

    private void KeepInBounds(){
        //Left and Right range
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // up and down range
        if(transform.position.y < yRangeMin)
        {
            transform.position = new Vector3(transform.position.x, yRangeMin, transform.position.z);
        }

        if(transform.position.y > yRangeMax)
        {
            transform.position = new Vector3(transform.position.y, yRangeMax , transform.position.z);
        }
    }

    private void JumpCharacter()
    {
        if (charRig.position.y == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                charRig.AddForce(transform.up *  jumpHeight, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //using a random number to determine how much damage will be done(10-20)
            System.Random random = new System.Random();
            int ranNum = random.Next(10,20);
            playerHp -= ranNum;

            StartCoroutine(HitCoroutine());
            
            healthBar.UpdateHealthBar(playerHp, maxHp);
        }
    }

    IEnumerator HitCoroutine()
    {
        animationControlScript.hitState = true;
        animator.SetInteger(animationState, 3);

        yield return new WaitForSeconds(.8f);

        animationControlScript.hitState = false;
    }
}
