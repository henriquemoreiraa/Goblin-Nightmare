using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUiController : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("Gameplay3");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
