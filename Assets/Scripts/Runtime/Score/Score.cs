using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Runtime.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highScoreText;
        
        private bool hintHasAlreadyBeenShowed = false;
        private bool solutionHasAlreadyBeenShowed = false;
        
        private bool countdownHasStarted;
        private bool gameIsFinished = false;
        
        private int currentScore = 6000;

        private int minusPointsHint = 120;
        private int minusPointsSolution = 360;

        
        private int highScore = 0;
        private string highScoreKey = "highscore";

        private void Awake()
        {
            SetHighScore(PlayerPrefs.GetInt(highScoreKey));
        }

        public void MinusPointsForHint()
        {
            if (hintHasAlreadyBeenShowed)
                return;

            SetCurrentScore(currentScore-minusPointsHint);
        }

        public void MinusPointsForSolution()
        {
            if (solutionHasAlreadyBeenShowed)
                return;

            SetCurrentScore(currentScore-minusPointsSolution);
        }


        private IEnumerator Countdown()
        {
            countdownHasStarted = true;

            // Set current score initially to ensure that it show
            // the correct text on the label.
            SetCurrentScore(currentScore);
                
            while(currentScore > 0 && !gameIsFinished)
            {
                yield return new WaitForSeconds(1);
                SetCurrentScore(currentScore - 1);
            }
        }

        public void StartCountdown()
        {
            if (countdownHasStarted)
                return;
            
            StartCoroutine(Countdown());
        }

        private void SetCurrentScore(int newCurrentScore)
        {
            currentScore = Math.Max(newCurrentScore, 0);
            scoreText.text = "Score: " + currentScore;
        }

        public void GameFinished()
        {
            if (currentScore > highScore)
            {
                SetHighScore(currentScore);
            }

            gameIsFinished = true;
        }

        private void SetHighScore(int newHighScore)
        {
            highScore = newHighScore;
            PlayerPrefs.SetInt(highScoreKey,highScore);
            highScoreText.text = "Your High Score: " + highScore;
        }
    }
}