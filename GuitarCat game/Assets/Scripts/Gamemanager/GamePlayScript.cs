using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayScript : MonoBehaviour {

	public static GamePlayScript instance;

	private Text scoreText, highScoreText, liveText, pointsText;
	private Text gameOverText, pointText;

	private int lives, score, points, highScore;

	[SerializeField]
	private GameObject gameOver;

	[SerializeField]
	private GameObject pausePanel;

	// Use this for initialization
	void Awake () {
		MakeInstance();
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		liveText = GameObject.Find("Lives").GetComponent<Text>();
		pointsText = GameObject.Find("Points").GetComponent<Text>();

		gameOverText = GameObject.Find("ScoreText").GetComponent<Text>();
		highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
		pointText = GameObject.Find("PointText").GetComponent<Text>();

		pausePanel = GameObject.FindGameObjectWithTag("Pause Panel");
		pausePanel.SetActive(false);

		lives = 3;

		gameOver.SetActive(false);

		highScore = PlayerPrefs.GetInt("highScore");
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoadedEvent; //subscribe to the event
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoadedEvent;
	}

	void MakeInstance(){
		if(instance == null){
			instance = this;
		}
	}

	void OnDestroy(){
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode){
		if(scene.name == "GamePlayScene"){
			if(GameManager.Instance.gameStartedFromMainMenu){
				GameManager.Instance.gameStartedFromMainMenu = false;
				lives = 3;
				points = 0;
				score = 0;
			} else if(GameManager.Instance.gameRestarted){
				GameManager.Instance.gameRestarted = false;
				lives = GameManager.Instance.lives;
				points = GameManager.Instance.points;
				score = GameManager.Instance.score;
			}
			liveText.text = "Lives: " + lives.ToString();
			pointsText.text = "Points: " + points.ToString();
			scoreText.text = "Score: " + score.ToString();
		}
	}

	public void IncrementScore(){
		score++;

		// scoreText.text = "Score: " + GameManager.Instance.score.ToString();
		scoreText.text = "Score: " + score.ToString();

		if(score > highScore){
			highScore = score;
		}
	}

	public void PlayerTakeDamage(){
		lives--;

		if(lives > 0){
			StartCoroutine(GameReload("GamePlayScene"));
			liveText.text = "Lives: " + lives.ToString();
			pointsText.text = "Points: " + points.ToString();
			scoreText.text = "Score: " + score.ToString();
		} else {
			StartCoroutine(WaitBeforeReplay());
		}
	}

	public void PlayerDestroyEnemy(){
		points++;
		pointsText.text = "Points: " + points.ToString();
	}

	IEnumerator GameReload(string sceneName){
		GameManager.Instance.lives = lives;
		GameManager.Instance.points = points;
		GameManager.Instance.score = score;
		GameManager.Instance.gameRestarted = true;

		yield return new WaitForSeconds(3f);

		SceneManager.LoadScene(sceneName);
	}

	IEnumerator WaitBeforeReplay(){
		yield return new WaitForSeconds(2f);
		liveText.text = "Lives: " + 0;
		gameOver.SetActive(true);

		gameOverText.text = "Score: " + score.ToString();
		highScoreText.text = "High Score: " + highScore.ToString();
		pointText.text = "Points: " + points.ToString();
	}

	public void PlayAgain(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("GamePlayScene");
	}

	public void PauseGame(){
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void ResumeGame(){
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void QuitGame(){
		Application.Quit();
	}

}
