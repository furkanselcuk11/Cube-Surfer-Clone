using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioController: MonoBehaviour
{
    public sound[] sounds;
    private picker thePlayer;

     void Awake()
    {
        foreach (var s in sounds)
        {
            thePlayer = FindObjectOfType<picker>();
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;            
        } 
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
    }
    public void Stop(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
    }
}
