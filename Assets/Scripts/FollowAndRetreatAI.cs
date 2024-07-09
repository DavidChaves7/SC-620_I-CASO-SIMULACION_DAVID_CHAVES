using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRetreatAI : MonoBehaviour
{
    #region Variables
    [Header("Follow")]
    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    [SerializeField]
    float stopDistance;

    [SerializeField]
    float retreatDistance;

    [Header("Fire")]
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletLifeTime;

    [SerializeField]
    float firetimeout;

    float _fireTimer;

    Rigidbody2D _rigidbody;
    #endregion

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _fireTimer = firetimeout;
    }

    private void FixedUpdate()
    {
        HandleFollow();

        //FIRE TO PLAYER 40 pts
        HandleBossFire();
    }

    private void HandleFollow()
    {
        float distance = Vector2.Distance(_rigidbody.position, target.position);

        if (distance > stopDistance)
        {
            _rigidbody.position =
                Vector2.MoveTowards(_rigidbody.position, target.position, speed * Time.fixedDeltaTime);
        }
        else if (distance < retreatDistance)
        {
            _rigidbody.position =
                Vector2.MoveTowards(_rigidbody.position, target.position, -speed * Time.fixedDeltaTime);
        }
        else if (distance < stopDistance && distance > retreatDistance)
        {
            _rigidbody.position = this._rigidbody.position;
        }

        transform.right = target.position - transform.position;
    }

    private void HandleBossFire()
    {
        _fireTimer -= Time.deltaTime;

        if (_fireTimer > 0.0F)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.transform.Rotate(0, 0, -90);

        Vector2 direction = (firePoint.position - transform.position).normalized;
        BossBulletController controller = bullet.GetComponent<BossBulletController>();
        controller.SetDirection(direction);

        Destroy(bullet, bulletLifeTime);
        _fireTimer = firetimeout;

    }
}
