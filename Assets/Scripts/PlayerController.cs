using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed = 20f;
	public float firingRate = 0.5f;
	
	private float xMin;// = -6f;
	private float xMax;// = 6f;
	
	void Start(){
		setBoundary();
	}
	
	public void setBoundary(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	public float getLeftMost(){return xMin;}
	public float getRightMost(){return xMax;}
	
	
	void Fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)) {
		   InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			//gameObject.transform.position += new Vector3(-speed * Time.deltaTime,  0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
			
		} 
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			//gameObject.transform.position += new Vector3(speed * Time.deltaTime,  0, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		//restrict the player to gamespace
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	
	}

}
