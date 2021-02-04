using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class settingsUI : MonoBehaviour
{

    public float totalbal1;

    public void reset()
    {
        PlayerPrefs.DeleteAll();
    }

   public void Watching()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
            totalbal1 = PlayerPrefs.GetFloat("totalBalance");
            totalbal1 = totalbal1 + 100;
            PlayerPrefs.SetFloat("totalBalance", totalbal1);
        }

        
    }

    public void Back()
    {
    SceneManager.LoadScene("Menu");
    }
}

