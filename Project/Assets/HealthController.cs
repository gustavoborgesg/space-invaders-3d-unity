using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Health health;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    
    void Update()
    {
        healthSlider.value = health.curHealth;
        healthText.text = String.Format($"{health.curHealth}/{health.maxHealth}");
    }
}
