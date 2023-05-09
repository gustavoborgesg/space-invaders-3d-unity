using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public int curHealth = 1;

    private void Start()
    {
        curHealth = maxHealth;
    }
}
