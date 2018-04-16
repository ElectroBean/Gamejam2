using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audSource;
    public AudioClip[] audioClips;
    public float pitchMin;
    public float pitchMax;


    private void Awake()
    {
        if(GetComponent<AudioSource>())
        {
            audSource = GetComponent<AudioSource>(); 
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.S))
        {
            PlaySound();
        }
	}

    public void PlaySound()
    {
        if(audioClips.Length == 0)
        {
            return;
        }
        int rand = Random.Range(0, audioClips.Length);
        float randPitch = Random.Range(pitchMin, pitchMax);
        if (audSource)
        {
            audSource.clip = audioClips[rand];
            audSource.pitch = randPitch;
        }
        else
        {
            gameObject.AddComponent<AudioSource>();
            audSource = GetComponent<AudioSource>();
            audSource.clip = audioClips[rand];
            audSource.pitch = randPitch;
        }

        audSource.Play();
    }
}
