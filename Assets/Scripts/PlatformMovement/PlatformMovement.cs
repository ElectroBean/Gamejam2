using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float scrollSpeed;
    public EndlessRunner er;
    bool hasSpawnedNext;
    public float lenthOfPlatform;
    public bool shouldSpawn;

    private void Awake()
    {
        er = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EndlessRunner>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
        //rb.MovePosition(transform.position + -transform.right * moveSpeedRB);
        Scroll();
        //if(transform.position.x <= 0 - lenthOfPlatform)
        //{
        //    Destroy(gameObject);
        //}

    }

    void Scroll()
    {
        transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (shouldSpawn)
        {
            if (other.gameObject.tag == "Player")
            {
                if (!hasSpawnedNext)
                {
                    er.SpawnPrefab(transform.position);
                    hasSpawnedNext = true;
                }
            }

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

