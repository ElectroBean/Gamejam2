using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float jumpheight;
    protected Collider coll; 
    public bool Canjump = false;
    public bool CanSlide = false;
    public bool CanAttack = false; 
    // Use this for initialization
    void Start () {
        coll = GetComponent<Collider>();
	}

    // Update is called once per frame
    void Update()
    {
        // if (Physics.Raycast(transform.position,downPosition))
        if (Canjump == true)
            if (Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y))
            {

                rb.AddForce(transform.up * jumpheight * 10);
                Canjump = false;
            }
    }
       
  public void Jump()
    {
        Update();
        Canjump = true; 
    }

    public void Attack()
    {
        //OnTriggerEnter(coll);
        CanAttack = true; 
    }
    private void OnTriggerStay(Collider coll)
    {
        if (CanAttack == true && coll.tag == "Enemy")
        {
           Destroy ( GameObject.FindWithTag("Enemy"));
           Debug.Log("Enemy HIt"); 
           CanAttack = false;
        }
        CanAttack = false;
    }
}
