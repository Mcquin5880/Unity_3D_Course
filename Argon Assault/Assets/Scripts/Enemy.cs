using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int enemyScoreValue;

    private void OnTriggerEnter(Collider other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        FindObjectOfType<ScoreBoard>().ScoreHit(enemyScoreValue);
        Destroy(gameObject);
    }
}
