using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool hasKey = false;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Transform textAimTarget;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private Transform worldSpaceCanvas;
    [SerializeField] private Vector3 offset;
    private GameObject text;
    private bool colliding = false;

    private void Start() {
        text = Instantiate(textPrefab, transform.position + offset, Quaternion.identity);
        text.transform.SetParent(worldSpaceCanvas);
        text.SetActive(false);
    }

    void Update() {
        text.transform.rotation = Quaternion.LookRotation(text.transform.position - textAimTarget.position);
        text.transform.position = transform.position + offset;
    }

    private void LateUpdate() {
        if(colliding && Input.GetKeyDown(KeyCode.E)) {
            sound.Play();
            this.gameObject.SetActive(false);
            hasKey = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        colliding = other.name.Equals("Player");
    }

    private void OnTriggerExit(Collider other) 
    {
        text.SetActive(false);
        colliding = false;
    }
}
