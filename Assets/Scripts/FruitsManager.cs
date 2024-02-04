using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class FruitsManager : MonoBehaviour
{

    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject bombPrefab;

    public float spawnSpeed = 1f;

    public float bombChance = 20;

    public GameObject bombSmoke;
    public GameObject bombSparkles;
    void Start()
    {
        Task testTask1 = AsyncTimer.Delay(spawnSpeed, CreateFruit, false);
    }

    void Update()
    {

    }
    void CreateFruit()
    {
        if(Application.isPlaying)
        {
            bool isBomb = Random.Range(0, 100) < bombChance;
            GameObject fruit;
            if (isBomb)
            {
                fruit = Instantiate(bombPrefab, bombPrefab.transform.position, bombPrefab.transform.rotation);
                GameObject smoke = Instantiate(bombSmoke, fruit.transform.position, fruit.transform.rotation);
                GameObject sparkles = Instantiate(bombSparkles, fruit.transform.position, fruit.transform.rotation);
                smoke.transform.parent = fruit.transform;
                sparkles.transform.parent = fruit.transform;
                smoke.transform.position += new Vector3(0, 0.8f, 0);
                sparkles.transform.position += new Vector3(0, 0.8f, 0);
            }
            else
            {
                var r = Random.Range(0, prefabs.Count);
                fruit = Instantiate(prefabs[r], prefabs[r].transform.position, prefabs[r].transform.rotation);
            }

            fruit.transform.position += new Vector3(Random.Range(-6, 6), 0, 0);

            int minXPower = -3;
            int maxXPower = 3;
            if(fruit.transform.position.x >= 4)
            {
                maxXPower -= 2;
            }
            if (fruit.transform.position.x <= -4)
            {
                minXPower += 2;
            }
            fruit.GetComponent<Food>().startSpeed = new Vector2(Random.Range(minXPower, maxXPower), Random.Range(12, 14));

            Task testTask = AsyncTimer.Delay(spawnSpeed, CreateFruit, false);
        }

    }





}
