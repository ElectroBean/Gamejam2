using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audSource;
    public AudioClip[] walkClips;
    public AudioClip[] slideClips;
    public AudioClip[] jumpClips;
    public AudioClip[] attackClips;
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
        InvokeRepeating("CheckSounds", 1, 1);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlaySound(string clipsToPlay)
    {
        switch (clipsToPlay)
        {
            case "Walk":
                if (walkClips.Length == 0)
                {
                    return;
                }
                int rand = Random.Range(0, walkClips.Length);
                float randPitch = Random.Range(pitchMin, pitchMax);
                if (audSource)
                {
                    audSource.clip = walkClips[rand];
                    audSource.pitch = randPitch;
                }
                else
                {
                    gameObject.AddComponent<AudioSource>();
                    audSource = GetComponent<AudioSource>();
                    audSource.clip = walkClips[rand];
                    audSource.pitch = randPitch;
                }

                audSource.Play();
                break;

            case "Slide":
                if (slideClips.Length == 0)
                {
                    return;
                }
                int superRand = Random.Range(0, slideClips.Length);
                float superRandPitch = Random.Range(pitchMin, pitchMax);
                if (audSource)
                {
                    audSource.clip = slideClips[superRand];
                    audSource.pitch = superRandPitch;
                }
                else
                {
                    gameObject.AddComponent<AudioSource>();
                    audSource = GetComponent<AudioSource>();
                    audSource.clip = slideClips[superRand];
                    audSource.pitch = superRandPitch;
                }

                audSource.Play();
                break;

            case "Attack":
                if (attackClips.Length == 0)
                {
                    return;
                }
                int superDuperRand = Random.Range(0, attackClips.Length);
                float superduperRandPitch = Random.Range(pitchMin, pitchMax);
                if (audSource)
                {
                    audSource.clip = attackClips[superDuperRand];
                    audSource.pitch = superduperRandPitch;
                }
                else
                {
                    gameObject.AddComponent<AudioSource>();
                    audSource = GetComponent<AudioSource>();
                    audSource.clip = attackClips[superDuperRand];
                    audSource.pitch = superduperRandPitch;
                }

                audSource.Play();
                break;

            case "Jump":
                if (jumpClips.Length == 0)
                {
                    return;
                }
                int superSuperDuperRand = Random.Range(0, jumpClips.Length);
                float superSuperduperRandPitch = Random.Range(pitchMin, pitchMax);
                if (audSource)
                {
                    audSource.clip = jumpClips[superSuperDuperRand];
                    audSource.pitch = superSuperduperRandPitch;
                }
                else
                {
                    gameObject.AddComponent<AudioSource>();
                    audSource = GetComponent<AudioSource>();
                    audSource.clip = jumpClips[superSuperDuperRand];
                    audSource.pitch = superSuperduperRandPitch;
                }

                audSource.Play();
                break;
        }
    }

    public void CreateNewAud()
    {
        AudioSource newAud = gameObject.AddComponent<AudioSource>() as AudioSource;
        int superSuperDuperRand = Random.Range(0, jumpClips.Length);
        float superSuperduperRandPitch = Random.Range(pitchMin, pitchMax);
        newAud.clip = attackClips[superSuperDuperRand];
        newAud.pitch = superSuperduperRandPitch;

        newAud.Play();
    }

    private void CheckSounds()
    {
        foreach (AudioSource a in GetComponents<AudioSource>())
        {
            if (!a.isPlaying)
            {
                Destroy(a);
            }
        }
    }
}
