using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyRespawn : MonoBehaviour
{
    public static int hoverCount = 3;
    public static int turretCount = 2;
    Text text;
    public Health playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    float x, y, z;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //jika player mati maka return
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        GameObject[] turret = GameObject.FindGameObjectsWithTag("Enemy_Turret");
        GameObject[] hover = GameObject.FindGameObjectsWithTag("Enemy_Hoverbot");

        if (hover.Length < 4)
        {
            //merandom posisi baru
            x = Random.Range(35, 75);
            y = -7.75f;
            z = Random.Range(-4, 15);

            //untuk mengisi 'rotation' di Instantiate dengan spawnPoints yang sudah kami buat di game
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            GameObject hoverTemp = GameObject.FindGameObjectWithTag("Enemy_Hoverbot");

            //function spawn
            if (hoverTemp != null)
            {
                Instantiate(hoverTemp, new Vector3(x, y, z), spawnPoints[spawnPointIndex].rotation);
                Debug.Log("____________________________________________Enemy Hover Bot Respawn");
                hoverCount++;
            }
            Debug.Log("Curr HoverBot Count: " + hoverCount);
        }

        if (turret.Length < 2)
        {
            //merandom posisi baru
            x = Random.Range(35, 75);
            y = -7.75f;
            z = Random.Range(-4, 15);

            //untuk mengisi 'rotation' di Instantiate dengan spawnPoints yang sudah kami buat di game
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            GameObject turretTemp = GameObject.FindGameObjectWithTag("Enemy_Turret");

            //function spawn
            if (turretTemp != null)
            {
                Instantiate(turretTemp, new Vector3(x, y, z), spawnPoints[spawnPointIndex].rotation);
                Debug.Log("____________________________________________Enemy Turret Respawn");
                hoverCount++;
            }
            Debug.Log("Curr Turret Count: " + turretCount);
        }

    }
}