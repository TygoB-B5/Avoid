using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{

    public Text totalbaltext;
    private float totalbal0;

    void Start()
    {
        totalbal0 = PlayerPrefs.GetFloat("totalBalance");
    }

    void Update()
    {
        totalbaltext.text = "Coins: " + totalbal0.ToString();
    }
    
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Scrol()
    {
        Debug.Log("hi");
    }
}
