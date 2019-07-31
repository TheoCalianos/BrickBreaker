using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,3f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointsPerBlock = 25;
    [SerializeField] TextMeshProUGUI scoreText;
    //state variables
    [SerializeField] int currentScore = 0;
    // Update is called once per frame
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }
    public void AddToScore()
    {
        currentScore += PointsPerBlock;
        scoreText.text = currentScore.ToString();
    }
}
