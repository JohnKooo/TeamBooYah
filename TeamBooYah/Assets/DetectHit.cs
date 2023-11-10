using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player2")
        {
            Debug.Log("Got Hit");
        }
        
    }

    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player 2")
        {
            Debug.Log("I hit the enemy");
        }
    }
}
