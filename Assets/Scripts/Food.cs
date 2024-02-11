 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{

    private Rigidbody2D rb;

    public Vector2 startSpeed;
    public float rotateSpeed;

    public bool isBomb = false;

    public GameObject fruitExplode;

    public Transform childLeft;
    public Transform childRight;


    public GameObject fruitSplash;
    public Color juiceColor;

    public AudioClip startSound;
    public AudioClip sliceSound;

    public GameObject FM;



    [System.Serializable]
    public class FoodEntry
    {
        public bool isBomb;
        public float delay;
        public float xPosition;
        public Vector2 velocity;
        public bool isRandomPosition;
        public bool isRandomVelocity;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = startSpeed;
        rb.angularVelocity = Random.Range(-rotateSpeed, rotateSpeed);

        AudioManager.Play(startSound, Random.Range(0.9f, 1), Random.Range(0.9f, 1.1f));
    }

    void Update()
    {
        if(transform.position.y < -6 && !isBomb)
        {
            Miss();
        }
        else if(transform.position.y < -6 && isBomb)
        {
            Destroy(gameObject);
        }
    }





    public void Miss()
    {
        FM.GetComponent<FruitsManager>().FruitLoose();
        Destroy(gameObject);
    }
    public void Slice()
    {

        AudioManager.Play(sliceSound, Random.Range(0.6f, 1), Random.Range(0.9f, 1.1f));
        GameObject particles = Instantiate(fruitExplode, transform.position, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().startColor = juiceColor;


        if (!isBomb)
        {
            GameObject splashParticles = Instantiate(fruitSplash, transform.position, Quaternion.identity);
            splashParticles.GetComponent<ParticleSystem>().startColor = juiceColor;
            transform.DetachChildren();
            var childLeftrb = childLeft.AddComponent<Rigidbody2D>();
            var childRightrb = childRight.AddComponent<Rigidbody2D>();
            childLeftrb.velocity = new Vector2(rb.velocity.x + Random.Range(-2, -0.1f), rb.velocity.y + Random.Range(0.1f, 0.5f));
            childRightrb.velocity = new Vector2(rb.velocity.x + Random.Range(0.1f, 2), rb.velocity.y + Random.Range(0.1f, 0.5f));
        }
        if (isBomb)
        {
            FM.GetComponent<FruitsManager>().BombLoose(gameObject);
        }
        Destroy(gameObject);
    }



}
