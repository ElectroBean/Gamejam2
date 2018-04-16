using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour {

    public GameObject[] prefabs;
    public Vector3 tOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPrefab(Vector3 currentPos)
    {
        int randomNumber = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[randomNumber], currentPos + tOffset, Quaternion.identity);
    }
}
