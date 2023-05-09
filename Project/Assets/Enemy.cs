using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public uint killScore = 0;
    public float powerupDropProbability = 0f;
    public GameObject powerupPrefab;
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        Ammo   ammo   = otherCollider.gameObject.GetComponent<Ammo>();
        Health health = GetComponent<Health>();
        Player player = ammo.shooter.GetComponent<Player>();
        
        if (ammo != null)
        {
            health.curHealth -= ammo.damage;
            
            if (health.curHealth <= 0 && player != null)
            {
                if (Random.value < powerupDropProbability)
                {
                    DropPowerup();
                }
                
                Player.Score += killScore;
                Destroy(gameObject);
            }
        }
    }

    private void DropPowerup()
    {
        Vector3 position = transform.position;
        position.z = 0;
        Instantiate(powerupPrefab, position, Quaternion.identity);
    }
}