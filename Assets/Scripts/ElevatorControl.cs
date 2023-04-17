using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
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
        if(colliding) {
            if(Input.GetKeyDown(KeyCode.E)) {
                elevator.closeDoors();
                elevator.move(elevator.getFloor()-1);
            } else if(Input.GetKeyDown(KeyCode.Q)) {
                elevator.closeDoors();
                elevator.move(elevator.getFloor()+1);
            }
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
