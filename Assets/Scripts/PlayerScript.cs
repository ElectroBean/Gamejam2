using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float jumpheight;
    protected Collider coll; 
    public bool Ground = false;
    Ray myRay; 
    // Use this for initialization
    void Start () {
        coll = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

        // if (Physics.Raycast(transform.position,downPosition))

       if ( Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y))
            {
              if (Input.GetKey(KeyCode.Space))
                {
                rb.AddForce(transform.up * jumpheight);
            }
        }
     
       
	}

  
    public void ButtonClick()
    {
       // Debug.Log("test");
    }
}
