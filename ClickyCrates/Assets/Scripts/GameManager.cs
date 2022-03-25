using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; set; }

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText; 
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive ;

    private float _spawnRate = 1;

    private int score;
    
  
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets[randomIndex]);

        }
    }

    public void ScoreUpdate(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        Debug.Log("Rest");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
    }

    public void StartGame(int difficulty)
    {
            isGameActive = true;
            score = 0;

            titleScreen.gameObject.SetActive(false);
            
            _spawnRate /= difficulty;

            StartCoroutine(SpawnTarget());
            ScoreUpdate(0);
    }
    
}

