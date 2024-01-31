using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{

    public Vector3 offset;
    public float dumping;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        WorldPos.z = 0;
        transform.position = Vector3.SmoothDamp(transform.position, WorldPos + offset, ref velocity, dumping);
    }
}
