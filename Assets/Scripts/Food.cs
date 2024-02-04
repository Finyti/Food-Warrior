 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private Rigidbody2D rb;

    public Vector2 startSpeed;
    public float rotateSpeed;

    private bool isSlicing = false;

    public GameObject fruitExplode;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startSpeed;
        rb.angularVelocity = Random.Range(-rotateSpeed, rotateSpeed);
    }

    void Update()
    {
        if(transform.position.y < -6)
        {
            Miss();
        }
    }



    private void OnMouseOver()
    {
        Slice();
    }

    private void Miss()
    {
        FruitLoose();
        Destroy(gameObject);
    }
    private void Slice()
    {
        GameObject particles = Instantiate(fruitExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void FruitLoose()
    {

    }

}
