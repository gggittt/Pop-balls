using System;
using UnityEngine;


    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private GameOverScreen _loseScreen;

        private void OnEnable()
        {
            _player.Died += GameOverHandler;
        }
        private void OnDisable()
        {
            _player.Died -= GameOverHandler;
        }

        private void GameOverHandler()
        {
            _loseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void OnRestartButtonClicked()
        {
            RestartGame();
        }

        private void RestartGame()
        {
            _player.ResetStats();
            Time.timeScale = 1.0f;
            PopAllBalls();
            _loseScreen.gameObject.SetActive(false);
        }

        private void PopAllBalls()
        {
            Ball[] allBalls = FindObjectsOfType<Ball>();
            foreach (Ball item in allBalls)
            {
                item.Deactivate();
            }
        }
    }    