using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{  
    [SerializeField] private AudioSource source;
    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
