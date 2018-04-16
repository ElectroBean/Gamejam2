using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float jumpheight;
    public bool Ground = false; 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.right * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpheight);
        }

       
        //rb.velocity = new Vector3(speed, 0, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
