using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 1f;

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		
		if (missle) {
			health -= missle.GetDamage();
			missle.Hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
