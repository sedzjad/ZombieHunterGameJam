using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


	private void Update() {
		if (Input.GetButtonDown("Fire1")) {
			StartGame();
		}
	}
	public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
