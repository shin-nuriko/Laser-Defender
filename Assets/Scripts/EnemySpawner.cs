using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 3f;
		
	private bool movingRight = true;

	
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.FindObjectOfType<PlayerController>();	
		playerController.setBoundary();
		
		foreach( Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(movingRight) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		} else {
			transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
	
		if (rightEdgeOfFormation >= playerController.getRightMost() ) {
			movingRight = false;
		}
		if (leftEdgeOfFormation <= playerController.getLeftMost() ) {
			movingRight = true;
		}		
		

	}
}
