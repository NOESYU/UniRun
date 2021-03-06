using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글톤

    public bool isGameover = false;
    public Text lifeText;
    public Text scoreText;
    public GameObject gameoverUI;

    private int score = 0;
    private int life;

    public GameObject MenuPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            // SceneManager.LoadScene("Main");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void PlayerLife(int newLife)
    {
        if (!isGameover)
        {
            life = newLife;
            lifeText.text = life.ToString();
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void ClickeMenuButton()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClickeMenuPanel()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
