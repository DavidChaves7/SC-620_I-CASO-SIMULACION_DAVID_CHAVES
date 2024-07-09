using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D _rigidbody;

    Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _rigidbody.velocity = _direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CentinelController controller = collision.gameObject.GetComponent<CentinelController>();

            //Implement GetPoints on CentinelContrroller 10 pts
            float points = controller.GetPoints();

            //IMPLEMENT Singlenton(Instance) to Invoke IncreaseScore 10 pts (Mismo paso que en UI Controller)
            UIController.Instance.IncreaseScore(points);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossController controller = collision.gameObject.GetComponent<BossController>();
            controller.TakeHit();
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
