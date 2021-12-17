using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
    }

    public void Play(string name){
       Sound s =  Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
