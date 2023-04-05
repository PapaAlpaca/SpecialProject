using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private Transform mainCam;
    [SerializeField] private Transform target;
    [SerializeField] private Transform worldSpaceCanvas;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        mainCam = Camera.main.transform;
        transform.SetParent(worldSpaceCanvas);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = target.position + offset;
    }
}
