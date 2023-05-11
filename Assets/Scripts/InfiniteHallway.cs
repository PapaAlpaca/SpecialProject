using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallway : MonoBehaviour
{
    [SerializeField] private GameObject hallwayPrefab;
    private int size = 100;
    private float hallwayLength = 20.06f;

    void Start()
    {
        for(int i = 0; i < size; i++) {
            Instantiate(hallwayPrefab, (transform.position) + new Vector3(i*hallwayLength, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    void OnTriggerEnter() {
        Debug.Log("increasing");
        int increase = 10;
        GetComponent<BoxCollider>().center += new Vector3(increase*hallwayLength, 0.0f, 0.0f);
        for(int i = size; i < size + increase; i++) {
            Instantiate(hallwayPrefab, transform.position + new Vector3(i*hallwayLength, 0.0f, 0.0f), Quaternion.identity);
        }
        size += increase;
    }
}
