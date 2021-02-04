using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;

    public float spawnTime;
    public float spawnPerblock;
    public float speedbuildupPerblock;
    public float maxSpeed;
    public float maxBuildup;

    public int points;
    public int highscore;

    public Text countText;
    public Text highText;

    public float buildup;
    private float LR_;
    private float LR;
    private float timer;

    public UIbuttons uibut;

    public float totalbal_;

    public bool running = true;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highText.text = "Highscore:" + highscore.ToString();
    }

    void Update()
    {
        if (LR_ >= 0)
        {
            LR = -1f;
        }
        if (LR_ <= 0)
        {
            LR = 1f;
        }

        if (running == true)
        {
            timer = timer + 1 * Time.deltaTime;

            if (timer >= spawnTime)
            {
                if (timer >= maxSpeed)
                {
                    spawnTime = spawnTime - spawnPerblock;
                }
                if (buildup <= maxBuildup)
                {
                    buildup = buildup + speedbuildupPerblock;
                }

                enemySpawn();
                timer = 0f;

            }
        }
    }

    void enemySpawn()
    {

        LR_ = Random.Range(-1f, 1f);

        if (running == true)
        {
            if (uibut.died1time == true)
            {
                Instantiate(enemy2, new Vector3(LR, 6f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, new Vector3(LR, 6f, 0f), Quaternion.identity);
            }
        }
    }

    public void Count()
    {
        points = points + 1;

        if (points >= highscore || points == highscore)
        {
            highscore = points;
        }

        countText.text = "Score: " + points.ToString();
        highText.text = "Highscore:" + highscore.ToString();

        totalbal_ = totalbal_ + 1;
        

    }

    public void timescale()
    {

        running = false;
    }
}
