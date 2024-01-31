 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private Rigidbody2D rb;

    public Vector2 startSpeed;

    private bool isSlicing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startSpeed;
    }

    void Update()
    {
        if(transform.position.y < -6)
        {
            FruitLoose();
            Destroy(gameObject);
        }
    }

    void FruitLoose()
    {

    }

    private void OnMouseOver()
    {
        print("FFF");
    }

}
