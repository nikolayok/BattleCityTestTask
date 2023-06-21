using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinEvents : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameOverEvents _gameOverEvents;

    private void Start()
    {
        InvokeRepeating("CheckForEnemies", 2, 2);
    }

    private void CheckForEnemies()
    {
        if (_enemySpawner.GetAmountOfEnemies() == _enemySpawner.GetEnemiesCount())
        {
            GameObject enemy = GameObject.FindWithTag("EnemyTank");
            if (enemy == null)
            {
                GameWin();
            }
        }
    }

    private void GameWin()
    {
        Debug.Log("Game Win");
        _gameOverEvents.ShowGameOverCanvas();
    }
}
