using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slicer : MonoBehaviour
{

    public Vector3 offset;
    public float dumping;

    private Vector3 velocity = Vector3.zero;

    private CircleCollider2D cd;

    public GameObject gm;

    public GameObject textManager;






    void Start()
    {
        cd = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        WorldPos.z = 0;
        transform.position = Vector3.SmoothDamp(transform.position, WorldPos + offset, ref velocity, dumping);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Food>().isBomb)
        {
            gm.GetComponent<GameManager>().AddCombo();
            textManager.GetComponent<TextManager>().Score += 1;
        }
        collision.gameObject.GetComponent<Food>().Slice();

    }




}
