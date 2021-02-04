using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform player;
    public UIbuttons uibuttons;

    public void Left()
    {
        player.transform.position = new Vector3(1, player.position.y, player.position.z);
    }

    public void Right()
    {
        player.transform.position = new Vector3(-1f, player.position.y, player.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.transform.position = new Vector3(1, player.position.y, player.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.transform.position = new Vector3(-1, player.position.y, player.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Death2"))
        {
            uibuttons.Death();
        }
    }
}
