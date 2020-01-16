using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class rocketScripts : MonoBehaviour
{
    [Header("Custom")]
    public Transform target;
    public Rigidbody rb;

    [Header("LifeTime of the missile")]
    public float maxLifeTime = 15f;

    public float turn;
    public float velocity;

    public float damage;
    Health m_PlayerHealth;

    [Header("VFX")]
    public GameObject deathVFX;
    public Transform deathVFXSpawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnVFX", maxLifeTime, 1);
        Destroy(this.gameObject, maxLifeTime);
    }

    private void SpawnVFX()
    {
        if(deathVFXSpawnPoint != null && deathVFX != null) {
            var vfx = Instantiate(deathVFX, deathVFXSpawnPoint.position, Quaternion.identity);
            Destroy(vfx, 5f);
        }
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
            target = targetObject.transform;
        }

        rb.velocity = transform.forward * velocity;
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

            m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this, playerCharacterController.gameObject);
            m_PlayerHealth.currentHealth -= damage;

            SpawnVFX();
            Destroy(gameObject);

            Debug.Log("Missile kena player. Curr Missile Count: " + missleRespawn.missileCount);
            return;
        }
    }



}
