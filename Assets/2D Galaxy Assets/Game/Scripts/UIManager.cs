using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        // si eres igual a 50 pon la funcion para cambiar de scene
        /* if(score >= 50){
            SceneManager.LoadScene("Nivel2");
        } */
    }

    public int GetScore(){
        return score;
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
