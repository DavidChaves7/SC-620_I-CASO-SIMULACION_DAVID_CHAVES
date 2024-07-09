using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // 5 PLAYER BULLETS DESTROYS BOSS 10 pts
    [Header("Life")]
    [SerializeField]
    float maxLifeBullets;

    [Header("Points")]
    [SerializeField]
    float points;

    [Header("Enemies")]
    [SerializeField]
    Transform enemies;

    float _currentHits = 0;

    public void TakeHit()
    {
        _currentHits++;
        if(_currentHits== maxLifeBullets)
        {
            UIController.Instance.IncreaseScore(points);
            Destroy(gameObject);
            enemies.gameObject.SetActive(true);
        }
    }

    
}
