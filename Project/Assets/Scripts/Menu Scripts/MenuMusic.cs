using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource AudioSource;

    // Use this for initialization
    void Start()
    {
        //Plays menu music
        AudioSource.Play();
    }
}
