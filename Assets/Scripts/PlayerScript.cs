using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject player;
    public Rigidbody rb;
    //player speed
    public float speed;
    public float fallMulitplier; 
    // Jump
    public float jumpheight;
    //how long the player will slide
    public float SlideTime; 
    //resets slide time
    private float Timer; 

    public bool Canjump = false;
    public bool CanSlide = false;
    public bool CanAttack = false;

    protected Collider coll;
    // Use this for initialization
    void Start () {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        SlideTime = Timer; 
	}

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulitplier - 1) * Time.deltaTime;
        }
        //  else if (rb.velocity.y > 0)
        //  {
        //      rb.velocity += Vector3.up * Physics.gravity.y * (jumpheight - 1) * Time.deltaTime;
        // 
        //  }
        // if (Physics.Raycast(transform.position,downPosition))
        Debug.DrawRay(transform.position, Vector3.down * coll.bounds.extents.y / 2.5f, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y / 2.5f))
        {
            if (Canjump == true)
            {
               
                // rb.AddForce(transform.up * jumpheight * 10);
                rb.velocity = Vector3.up * jumpheight;
            }
        }
        Canjump = false;

        if (CanSlide == true)
        {
            player.SetActive(false);
            SlideTime += Time.deltaTime;
            if (SlideTime >= 1)
            {
                player.SetActive(true);
                CanSlide = false;
                SlideTime = Timer ; 
            }
        }

        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
    }
       
  public void Jump()
    {
        //Update();
        Canjump = true; 
    }

    public void Attack()
    {
        //OnTriggerEnter(coll);
        CanAttack = true; 
    }
    public void Slide()
    {
        Update();
        CanSlide = true;

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
