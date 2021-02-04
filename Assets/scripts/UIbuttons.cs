using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UIbuttons : MonoBehaviour
{
    public GameObject uipanel;
    public GameObject deathpanel;
    public GameObject clickTocontinue_;

    public bool paused = false;

    public enemyController enem;

    public float totalbal;
    public bool isDead = false;
    public float count = 5;
    public float totalbal2try;
    public float totalbalcur;

    private bool clickedRetry = false;
    public bool died1time = false;

    public float totalBlocksPassed;

    private float randomad;

    public Text retryCounttext;

    void Start()
    {
        totalbal = PlayerPrefs.GetFloat("totalBalance");
        totalBlocksPassed = PlayerPrefs.GetFloat("totalBlocksPassed");
    }

    public void Pause()
    {
        paused = !paused;
    }

    void Update()
    {
        if (isDead == false)
        {
            if (paused == true)
            {
                uipanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                uipanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else
        {
            Time.timeScale = 0;
            count = count - 1 * Time.unscaledDeltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        retryCounttext.text = "Retry " + count.ToString("F1");

        if (clickedRetry == false)
        {
            if (count <= 0f)
            {
                checkout();
            }
        }


    }

    public void Quit()
    {
        checkout();
    }

    public void Death()
    {
        isDead = true;

        PlayerPrefs.SetInt("Highscore", enem.highscore);

        deathpanel.SetActive(true);

        Time.timeScale = 0f;

        totalbalcur = totalbalcur + enem.totalbal_ - totalbal2try;

        if (died1time == true)
        {
            checkout();
        }

    }

    public void Retry()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            clickedRetry = true;
            died1time = true;

            totalbal2try = totalbalcur;

            Advertisement.Show("rewardedVideo");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Death");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);

            deathpanel.SetActive(false);
            isDead = false;

            clickTocontinue_.SetActive(true);
            enem.timescale();

        }
    }

    public void Clicktocontinue()
    {
        clickTocontinue_.SetActive(false);
        enem.running = true;
    }

    void checkout()
    {

        randomad = Random.Range(0f, 1f);
        if (randomad <= 0.20f)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
        }
        totalbal = totalbal + totalbalcur;
        totalBlocksPassed = totalbalcur + totalBlocksPassed;

        PlayerPrefs.SetFloat("totalBlocksPassed", totalBlocksPassed);
        PlayerPrefs.SetFloat("totalBalance", totalbal);
        SceneManager.LoadScene("Menu");
    }
}