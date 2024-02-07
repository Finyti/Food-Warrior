using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;
using static Food;


public class FruitsManager : MonoBehaviour
{

    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject bombPrefab;

    public float spawnSpeed = 3f;

    public float bombChance = 20;

    public GameObject bombSmoke;
    public GameObject bombSparkles;

    public int currentWave = 0;

    public List<Wave> waveProperties;

    [System.Serializable]



    public class Wave
    {
        public float waveTime;
        public List<FoodEntry> foods = new List<FoodEntry>();
    }






    async void Start()
    {
        NextWave();
        //await new WaitForSeconds(5f);
        //Task testTask1 = AsyncTimer.Delay(spawnSpeed, CreateFruit, false);
    }

    void Update()
    {

    }



    async void NextWave()
    {
        if (currentWave < waveProperties.Count)
        {
            print(1);
            var foodsList = waveProperties[currentWave].foods;
            await new WaitForSeconds(waveProperties[currentWave].waveTime);
            foreach (var food in foodsList)
            {

                CreateFruit(food);
            }
            currentWave++;
            NextWave();
        }


    }
    async void CreateFruit(FoodEntry currentFood)
    {
        if (Application.isPlaying)
        {
            await new WaitForSeconds(currentFood.delay);
            bool isBomb = currentFood.isBomb;
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

            if (!currentFood.isRandomPosition)
            {
                fruit.transform.position += new Vector3(currentFood.xPosition, 0, 0);
            }
            else
            {
                fruit.transform.position += new Vector3(Random.Range(-6, 6), 0, 0);
            }
            if (!currentFood.isRandomVelocity)
            {
                fruit.GetComponent<Food>().startSpeed = new Vector2(currentFood.velocity.x, currentFood.velocity.y);
            }
            else
            {
                float xMultiplier = Random.Range(0.9f, 1.1f);
                fruit.GetComponent<Food>().startSpeed = new Vector2(currentFood.velocity.x * xMultiplier, Random.Range(12, 14));
            }


        }

    }





}
