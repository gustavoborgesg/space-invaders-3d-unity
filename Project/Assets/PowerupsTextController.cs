using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerupsTextController : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI text;
    
    void Update()
    {
        text.text = String.Format($"Powerups: {player.ammoPowerCapacity}");
    }
}
