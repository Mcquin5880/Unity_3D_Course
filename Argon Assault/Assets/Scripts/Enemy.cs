using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int healthPoints = 5;
    [SerializeField] int enemyScoreValue;

    ScoreBoard scoreboard;

    private void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        healthPoints--;
        if (healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        scoreboard.ScoreHit(enemyScoreValue);
        Destroy(gameObject);
    }
}
