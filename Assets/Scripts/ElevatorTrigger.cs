using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Elevator elevator;

    void OnTriggerEnter(Collider other)
    {
        elevator.move(true);
    }
}
