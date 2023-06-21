using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverEvents : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private Text _pointsText;
    private PlayerStatistics _playerStatistics;

    private void Start() 
    {
        _playerStatistics = GameObject.FindWithTag("PlayerStatistics").GetComponent<PlayerStatistics>();
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowGameOverCanvas()
    {
        _pointsText.text = "Points: " + _playerStatistics.GetPoints().ToString();
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
