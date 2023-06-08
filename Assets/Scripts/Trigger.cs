using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private string caption;
    [SerializeField] private int length;
    [SerializeField] private GameObject textBox;

    void OnTriggerEnter(Collider other)
    {
        if(sound != null) sound.Play();
        if(caption != null && length != 0 && textBox != null) (textBox.GetComponent<TextPopup>()).setText(caption, length);
    }
}
