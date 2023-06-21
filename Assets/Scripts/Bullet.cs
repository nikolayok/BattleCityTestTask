using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletLifeTime = 5;
    private PlayerHealth _playerHealth;
    private GameOverEvents _gameOverEvents;
    private PlayerStatistics _playerStatistics;

    private void Awake() 
    {
        _gameOverEvents = GameObject.FindWithTag("GameOverEvents").GetComponent<GameOverEvents>();
        _playerHealth = GameObject.FindWithTag("PlayerHealth").GetComponent<PlayerHealth>();
        _playerStatistics = GameObject.FindWithTag("PlayerStatistics").GetComponent<PlayerStatistics>();
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        string colliderName = collision.gameObject.tag;
        if (colliderName != "Border" && colliderName != "SteelWall")
        {
            if (colliderName == "Base")
            {
                GameOver();
            }
            else if (colliderName == "EnemyTank")
            {
                _playerStatistics.AddPoints();
            }

            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }

    private void GameOver()
    {
        _gameOverEvents.ShowGameOverCanvas();
    }
}
