using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	private void Start()
	{
		GameManager.instance.uiManager = this;
	}

	public void SceneChange(string sceneName)
	{
		GameManager.instance.Unpause();
		SceneManager.LoadScene(sceneName);
	}

	public string SceneName()
	{
		return SceneManager.GetActiveScene().name;
    }

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
