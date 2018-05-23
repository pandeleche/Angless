using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour {

	public Text best_score_text;
	public Text score_text;
	public Text congratulations_text;

	private float best_score;
	private float actual_score;


	void Start(){
		DynamicGI.UpdateEnvironment();
		actual_score = ScoreScript.score - ScoreScript.employed_time/10;
		checkScore ();
		best_score_text.text = best_score_text.text + best_score.ToString();
		score_text.text = score_text.text + actual_score.ToString();
	}

	public float getBestScore (){
		return best_score;
	}
	public void checkScore(){
		if (actual_score > best_score) {
			best_score = actual_score;
			congratulations_text.text = "CONGRATULATIONS!!!!!";
		}
	}

}


/*
public class DataController : MonoBehaviour {

	private RoundData[] allRoundData;
	private PlayerProgress playerProgress;

	private string gameDataFileName = "data.json";

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		LoadGameData();

		LoadPlayerProgress();
	}

	public RoundData GetCurrentRoundData(){
		return allRoundData [0];
	}

	public void SubmitNewPlayerScore(float newScore, string player){
		for (int i=0;i<10;i++) {
			if (playerProgress.highest_scores[i]== 0 || newScore < playerProgress.highest_scores[i]) {
				float aux_score = playerProgress.highest_scores[i];
				float aux_name = playerProgress.player_names [i];
				playerProgress.highest_scores[i] = newScore;
				playerProgress.player_names [i] = player;
				newScore = aux_score;
				player = aux_name;
			}
		}
	}

	public float[] GetHighestPlayerScore(){
		return playerProgress.highest_scores;
	}

	public string[] GetHighestScoreNames(){
		return playerProgress.player_names;
	}

	private void LoadGameData(){
		string filePath = Path.Combine (Application.streamingAssetsPath, gameDataFileName);

		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (FilePath);

			GameData loadedData = JsonUtility.FromJson (dataAsJson);


			allRoundData = loadedData.allRoundData;
		} else {
			Debug.LogError ("Cannot load game data!");
		}
	}

	private void LoadPlayerProgress(){
		playerProgress = new PlayerProgress ();

		if (PlayerPrefs.HasKey ("highest_scores")) {
			for(int i=0;i<10;i++){
				playerProgress.highest_scores [i] = PlayerPrefs.GetFloat ("highest_scores"+i.ToString());
			}
		}
	}

	private void SavePlayerProgress(){
		for(int i=0;i<10;i++){
			PlayerPrefs.SetFloat ("highest_scores" + i.ToString (), playerProgress.highest_scores [i]);
		}
	}
}*/
