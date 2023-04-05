using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject displayText;
    private boolean colliding = false;

    private void LateUpdate() {
        if(colliding && Input.GetKeyDown(KeyCode.E)) {
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        displayText.SetActive(true);
        if(other.name.equals("Player"))
        {
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        displayText.SetActive(false);
        colliding = false;
    }
}
