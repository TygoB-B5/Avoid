using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MenuUI : MonoBehaviour
{
    public Text hightext;
    public Text totalbaltext;
    public float totalbal0;
    public int highscore0;

     void Start()
    {
        totalbal0 = PlayerPrefs.GetFloat("totalBalance");
        highscore0 = PlayerPrefs.GetInt("Highscore");

        Debug.Log(PlayerPrefs.GetFloat("totalBlocksPassed"));
        

        hightext.text = "Highscore: " + highscore0.ToString();
        totalbaltext.text = "Coins: " + totalbal0.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Delete))
        {
            if(Input.GetKeyDown(KeyCode.RightShift))
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
