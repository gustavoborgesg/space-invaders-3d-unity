using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonController : MonoBehaviour
{
    public void StartGameOver()
    {
        SceneManager.LoadScene("GameScene");
    }
}
