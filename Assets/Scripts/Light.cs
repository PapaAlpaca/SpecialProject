using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private Material litMaterial;
    [SerializeField] private Material unlitMaterial;
    [SerializeField] private new GameObject light;
    [SerializeField] private Transform textAimTarget;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private Transform worldSpaceCanvas;
    [SerializeField] private Vector3 offset;
    private GameObject text;
    private bool lit = true;
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
            if(!lit) { sound.Play(); }
            text.SetActive(false);
            Material[] currMats = GetComponent<Renderer>().materials;
            // Debug.Log(string.Concat((object[])currMats));
            currMats[1] = lit? unlitMaterial: litMaterial;
            GetComponent<Renderer>().materials = currMats;
            lit = !lit;
            light.SetActive(lit);
        }
    }

    void OnTriggerEnter(Collider other) {
        text.SetActive(true);
        colliding = other.name.Equals("Player");
    }

    private void OnTriggerExit(Collider other) {
        text.SetActive(false);
        colliding = false;
    }
}
