using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLifesAndEnemiesLeft : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Text _playerHealthText;

    private void Start() 
    {
        InvokeRepeating("UpdateUI", 0f, 0.5f);
    }

    private void UpdateUI()
    {
        _playerHealthText.text = "Player health: " + _playerHealth.GetCurrentHealth().ToString();
    }
}
