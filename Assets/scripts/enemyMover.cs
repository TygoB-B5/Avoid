using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    public GameObject obj;
    public enemyController enem;

    void Update()
    {
        transform.Translate(Vector3.down * enem.buildup * Time.deltaTime);

        if (obj.transform.position.y <= -6)
        {
            Destroy(obj, 0);
            enem.Count();
        }
    }
}
