using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {
	public void LoadGame()
	{
		SceneManager.LoadScene("Door_project", LoadSceneMode.Single);
	}
	public void ExitGame()
	{
		Debug.Log("QUIT!!!");
		Application.Quit();
	}
}