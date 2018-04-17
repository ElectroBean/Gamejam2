using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float jumpheight;
    public float SlideTime; 
    private float Sliding;
    private float Timer; 
    protected Collider coll;
    public GameObject player;
    public bool Canjump = false;
    public bool CanSlide = false;
    public bool CanAttack = false; 
    // Use this for initialization
    void Start () {
        coll = GetComponent<Collider>();
        SlideTime = Timer; 
	}

    // Update is called once per frame
    void Update()
    {
            // if (Physics.Raycast(transform.position,downPosition))
        if (Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y))
        {
            if (Canjump == true)
            {
                // rb.AddForce(transform.up * jumpheight * 10);
                rb.AddForce(new Vector3(0, jumpheight, 0), ForceMode.Impulse);
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
