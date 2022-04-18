using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;

	public Camera cam;
	Vector2 mousePos;

	public int hpMax = 10;
	public int hpCurr;

	public HealthBar healthBar;

	public GameObject effect;

	void Start() {
		hpCurr = hpMax;
		healthBar.SetMaxHealth(hpMax);
	}

	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

		if(hpCurr <= 0)
        {
			Death();
			Time.timeScale = 0f;
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
	}

	public void TakeDamage(int damage) {
		hpCurr -= damage;
		healthBar.SetHealth(hpCurr);
	}

	void Death() {
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
