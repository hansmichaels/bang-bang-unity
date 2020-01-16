using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missleRespawn : MonoBehaviour
{
    public static int missileCount = 1;
    public Health playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    float x, y, z;
    Text text;
    Vector3 pos;

    public GameObject[] missileObjects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void Spawn()
    {
        missileObjects = GameObject.FindGameObjectsWithTag("Missile");

        //jika player mati maka return
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if (missileObjects.Length < 5)
        {
            //merandom posisi baru
            x = Random.Range(35, 75);
            y = 5f;
            z = Random.Range(-4, 15);

            //untuk mengisi 'rotation' di Instantiate dengan spawnPoints yang sudah kami buat di game
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            if(enemy != null)
            {
                Instantiate(enemy, new Vector3(x, y, z), spawnPoints[spawnPointIndex].rotation);
                Debug.Log("-------------------Misile spawned");
            }
        }

    }
}
