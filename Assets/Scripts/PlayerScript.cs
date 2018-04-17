using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

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
    private bool isAlive = true;

    private AudioManager audMan;
    public float walkSoundDelay;
    public float attackSoundDelay;
    private float walkSoundTimer = 0.45f;
    private float attackSoundTimer = 0.3f;
    bool grounded;

    bool startedSlide = false;

    protected Collider coll;

    private void Awake()
    {
        audMan = GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        SlideTime = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        attackSoundTimer -= Time.deltaTime;
        walkSoundTimer -= Time.deltaTime;

        if (grounded && !CanSlide)
        {
            if (walkSoundTimer <= 0)
            {
                audMan.PlaySound("Walk");
                walkSoundTimer = walkSoundDelay;
            }
        }

        if (CanAttack)
        {
            if (attackSoundTimer <= 0)
            {
                audMan.PlaySound("Attack");
                attackSoundTimer = attackSoundDelay;
            }
        }

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
            grounded = true;
            if (Canjump == true)
            {

                // rb.AddForce(transform.up * jumpheight * 10);

                rb.velocity = Vector3.up * jumpheight;
                foreach (AudioSource a in GetComponents<AudioSource>())
                {
                    a.Stop();
                }
                audMan.PlaySound("Jump");
            }
        }
        else
        {
            grounded = false;
        }
        Canjump = false;

        if (CanSlide == true)
        {
            // player.SetActive(false);
            if (startedSlide)
            {
                audMan.PlaySound("Slide");
                startedSlide = false;
            }
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            SlideTime += Time.deltaTime;
            if (SlideTime >= 1)
            {
                //    player.SetActive(true);
                CanSlide = false;
                startedSlide = false;
                SlideTime = Timer;
                player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

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
        startedSlide = true;
        CanSlide = true;

    }
    private void OnTriggerStay(Collider coll)
    {
        if (CanAttack == true && coll.tag == "Hitbox")
        {
            Destroy(GameObject.FindWithTag("Hitbox"));
            Debug.Log("Enemy HIt");
            CanAttack = false;
        }
        CanAttack = false;
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.tag == "Enemy")
        {
            isAlive = false;
        }
        else if (coll.transform.tag == "Trap")
        {
            isAlive = false;

        }
        // else if (coll.transform.tag == "Boxes")
        // {
        //     Destroy(player);
        //
        // }
    }
    public bool IsAlive()
    {
        return isAlive;

    }
}
