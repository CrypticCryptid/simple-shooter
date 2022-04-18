using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Transform target;

    public int hpMax = 5;
    public int hpCurr;

    public GameObject effect;
    //public ScoreTracker score;

    // Start is called before the first frame update
    void Start()
    {
        hpCurr = hpMax;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (hpCurr <= 0)
        {
            //score.SetScore();
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>().TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        hpCurr -= damage;
    }

    void Death()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
