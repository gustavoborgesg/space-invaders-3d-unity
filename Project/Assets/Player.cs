using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public uint ammoPowerCapacity   = 1;
    public static uint HighestScore = 0;
    public static uint Score        = 0;

    private void Start()
    {
        HighestScore = (uint)PlayerPrefs.GetInt("HighScore", 0);
        Score        = 0;
    }

    private void OnDisable()
    {
        if (Score > HighestScore)
        {
            HighestScore = Score;
            PlayerPrefs.SetInt("HighScore", (int)HighestScore);
        }
    }
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        Ammo   ammo   = otherCollider.gameObject.GetComponent<Ammo>(); 
        Health health = GetComponent<Health>();
        
        if (ammo != null)
        {
            health.curHealth -= ammo.damage;

            if (health.curHealth <= 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}