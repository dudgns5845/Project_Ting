using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmPlayer : MonoBehaviour
{
    public AudioClip[] Music = new AudioClip[7];
    AudioSource audiosource;

    private void Awake()
    {
        audiosource = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audiosource.isPlaying)
            RandomPlay();
    }

    void RandomPlay()
    {
        audiosource.clip = Music[Random.Range(0, Music.Length)];
        audiosource.Play();
    }
}
