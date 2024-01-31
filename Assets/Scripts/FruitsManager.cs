using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class FruitsManager : MonoBehaviour
{

    public List<GameObject> prefabs = new List<GameObject>();

    public float spawnSpeed = 1f;
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
            var r = Random.Range(0, prefabs.Count);

            GameObject fruit = Instantiate(prefabs[r], prefabs[r].transform.position, prefabs[r].transform.rotation);
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
