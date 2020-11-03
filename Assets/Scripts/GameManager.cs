using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
 
    private static GameManager _instance;
    public static int score;
    public GameObject scoreText;
    public GameObject timerText;
    public GameObject highscoreText;
    float currCountdownValue = 1;
    public bool countdownStarted = false;
    public int highscore;
    public List<Vector3> randomNumber = new List<Vector3>();
    public GameObject Coin;
    public GameObject Trap;
    int ranNum;
    
    //singleton
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt ("HighScore", highscore);
        score = 0;
        timerText.SetActive(false);
        ListFill();
        
        Invoke("CoinSpawn", Random.Range(1, 5));
    }

    private void Update()
    {
        ranNum = Random.Range(1, 5);
        
        UpdateScore();
        CountdownRegulator();
        UpdateHighscore();
    }
     
    public void UpdateScore()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score = " + score.ToString();
    }

    public void UpdateHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
        }
        highscoreText.GetComponent<UnityEngine.UI.Text>().text = "HighScore " + highscore.ToString();

        PlayerPrefs.SetInt("HighScore", highscore);
    }

    public void CountdownRegulator()
    {
        if (timerText == !isActiveAndEnabled)
        {
            timerText.SetActive(true);
        }
        
        if (PlayerHealth.isAlive == false && countdownStarted == false)
        {
            countdownStarted = true;
            StartCoroutine(StartCountdown());
        }

        if (currCountdownValue == 0)
        {
            StopCoroutine(StartCountdown());
            timerText.SetActive(false);
            SceneManager.LoadScene(2);
            countdownStarted = false;
        }
    }
    
    public IEnumerator StartCountdown(float countdownValue = 5)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            timerText.GetComponent<UnityEngine.UI.Text>().text = "Time = " + currCountdownValue.ToString();
        }
    }

    private void CoinSpawn()
    {
        Vector3 temp = randomNumber[Random.Range(0, 9)];
        float delay = Random.Range(1, 5);

        Instantiate(Coin, temp, Coin.transform.rotation);
        
        Invoke("CoinSpawn", delay);
        
        Debug.Log(temp);
    }

    private void TrapSpawn()
    {

        float delay = Random.Range(1, 5);

            Instantiate(Trap, randomNumber[Random.Range(0, 9)], Coin.transform.rotation);
        
            Invoke("TrapSpawn", delay);
    }
    
    private Vector3 CreateVector()
    {
        return new Vector3(Random.Range(2, 1), Random.Range(1, 1), Random.Range(3, 1));
    }

    private void ListFill()
    {
        for (int i = 0; i < 10; i++)
        {
            randomNumber.Add(CreateVector());
        }
        /*randomNumber.Add( new Vector3(0, 1, 2));
        randomNumber.Add( new Vector3(2, 6, 6));
        randomNumber.Add( new Vector3(1, 3, 4));
        randomNumber.Add( new Vector3(10, 9, 2));
        randomNumber.Add( new Vector3(4, 1, 6));*/
    }
}
