using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

	public void Start(){
		DynamicGI.UpdateEnvironment();
	}
	public void LoadGame(string scene_name)
	{
		SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
	}
	public void RestartGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name,LoadSceneMode.Single);
	}
	public void ExitGame()
	{
		Debug.Log("QUIT!!!");
		Application.Quit();
	}
}