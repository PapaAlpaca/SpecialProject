using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }
}
