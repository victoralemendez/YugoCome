using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

    private PlayerMotor motor;

    private bool isGameStarted = false;

    //puntuacion
    private float score;
    private float coins;
    private float finalScore;

    //Text

    public Text scoreText;
    public Text coinsText;




   public bool IsGameStarted{
        get{
            return isGameStarted;
        }
    }
	private void Awake()
	{
        Instance = this;

        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
	}

	// Use this for initialization
	void Start () {
        UpdateScores();
	}
	
	// Update is called once per frame
	void Update () {
        if(isGameStarted){
            score += (Time.deltaTime * 2);
            scoreText.text = score.ToString("0");
        }        
	}

    public void StartGame(){
        isGameStarted = true;
        motor.StartRun();
    }

    public void GetCollectable(int collectableAmnt){
        coins++;
        score += collectableAmnt;
        UpdateScores();
        //Debug.Log(this.score);
    }

    public void GameOver(){
        finalScore = score + coins;
    }

    public void PlayAgain(){
        //iniciar el nivel nuevamente
        Invoke("LoadScene", 1f);
    }

    void LoadScene(){
        SceneManager.LoadScene(0);
    }

    public void UpdateScores(){
        scoreText.text = score.ToString("0");
        coinsText.text = coins.ToString("0");
    }
}
