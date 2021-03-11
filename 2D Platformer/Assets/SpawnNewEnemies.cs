using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewEnemies : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6;
    public bool spawned = false;
    public BoxCollider2D coll;

    public void Awake()
    {
        coll = GetComponent<BoxCollider2D>();

        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        enemy5.SetActive(false);
        enemy6.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !spawned)
        {
            if(enemy1 != null)
            {
                enemy1.SetActive(true);
            }

            if (enemy2 != null)
            {
                enemy2.SetActive(true);
            }

            if (enemy3 != null)
            {
                enemy3.SetActive(true);
            }

            if (enemy4 != null)
            {
                enemy4.SetActive(true);
            }

            if (enemy5 != null)
            {
                enemy5.SetActive(true);
            }

            if (enemy6 != null)
            {
                enemy6.SetActive(true);
            }

            spawned = true;
            coll.gameObject.SetActive(false);
        }
    }
}
