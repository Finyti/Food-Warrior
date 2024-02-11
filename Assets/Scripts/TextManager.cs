using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Food;
using static FruitsManager;

public class TextManager : MonoBehaviour
{
    public GameObject textPrefab;

    public int Score = 0;
    public GameObject ScoreText;
    public int Misses = 0;
    public GameObject MissesText;

    public bool loose = false;
    public List<TextCreator> TC;

    public List<GameObject> InstantiatedText;


    [System.Serializable]
    public class TextCreator
    {
        public Vector2 position;
        public string text;
        public GameObject textPrefab;
    }


    void Start()
    {
        ScoreText = Instantiate(textPrefab, new Vector2(0.5f, 4), Quaternion.identity);
        MissesText = Instantiate(textPrefab, new Vector2(11f, 4), Quaternion.identity);
        foreach (TextCreator tc in TC)
        {
            textInstantiate(tc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<TextMeshPro>().text = Score.ToString();
        MissesText.GetComponent<TextMeshPro>().text = Misses.ToString();
    }

    void textInstantiate(TextCreator tc)
    {
        GameObject newText = Instantiate(tc.textPrefab, tc.position, Quaternion.identity);
        newText.GetComponent<TextMeshPro>().text = tc.text;
        InstantiatedText.Add(newText);
    }
}
