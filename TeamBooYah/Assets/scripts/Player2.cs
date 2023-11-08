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
    private float horizontalInput;
    public Rigidbody charRig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        JumpCharacter();
        KeepInBounds();
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

        // down range
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
            charRig.AddForce(transform.up *  jumpHeight, ForceMode.Impulse );
        }
        }
        
    }
}
