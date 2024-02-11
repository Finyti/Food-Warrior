using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

public class GameManager : MonoBehaviour
{

    public int comboCount = 0;
    public bool comboRunning = false;

    public AudioClip comboSound;

    public GameObject textManager;
    void Start()
    {
        
    }


    void Update()
    {
        if (comboCount > 0 && !comboRunning)
        {
            comboRunning = true;
            ComboTimer();
        }
    }
    public void AddCombo()
    {
        comboCount += 1;
    }
    public void ComboTimer()
    {
        Task testTask1 = AsyncTimer.Delay(0.3f, Reset, false);
    }
    public void Reset()
    {
        if(comboCount > 2)
        {
            print("Combo!");
            AudioManager.Play(comboSound, Random.Range(0.9f, 1), Random.Range(0.9f, 1.1f));
            textManager.GetComponent<TextManager>().Score += 3;
        }
        else
        {
            print("No combo :(");
        }
        comboCount = 0;
        comboRunning = false;
    }
}
