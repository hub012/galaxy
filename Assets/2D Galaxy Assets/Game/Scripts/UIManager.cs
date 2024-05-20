using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public GameObject titleScreen;
    public Text scoreText;
    public int score = 0;

    public void Start(){
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
        if(currentLives <= 0 ){
            ResetScore();
        }
    }
    public void UpdateScore()
    {
        score += 2;

        scoreText.text = "Score: " + score;

    }

    public void ResetScore()
    {
        score = 0;

        scoreText.text = "Score: " + score;

    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }
    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
       scoreText.text = "Score: " + score;
    }

}
