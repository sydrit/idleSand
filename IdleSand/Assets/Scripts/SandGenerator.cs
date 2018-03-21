using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGenerator : MonoBehaviour {
	public GameObject grain;
	Vector3 startingPoint;
	public float speed;
	public float width;
	public float height;
	public float dropSpeed;
	public Color color;

	float timeCounter;
	// Use this for initialization
	void Start () {
		dropSpeed = 1;
		startingPoint = transform.position;
		InvokeRepeating ("spawnGrain", dropSpeed, dropSpeed);

	}
	
	// Update is called once per frame
	void Update () {
	//	transform.RotateAround (Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		timeCounter += Time.deltaTime * speed;

		float x = Mathf.Cos (timeCounter) * width;
		float y = 5;
		float z = Mathf.Sin (timeCounter) * height;
		transform.position = new Vector3 (x, y, z);

	}
	void spawnGrain(){
		grain.transform.position = transform.position;
		GameObject newGrain = Instantiate (grain);
		newGrain.GetComponent<Renderer> ().material.color = color;

	}
	public void changeColor(){
		ColorHSV randomHSV = new ColorHSV(Random.Range(0.0f, 360.0f), 1.0f, 1.0f);
		color = randomHSV.ToColor();

	}
	public void increaseDropSpeed(){
		dropSpeed -= .1f;
		CancelInvoke ();
		InvokeRepeating ("spawnGrain", dropSpeed, dropSpeed);


	}
	public void decreaseDropSpeed(){
		dropSpeed += .1f;
		CancelInvoke ();
		InvokeRepeating ("spawnGrain", dropSpeed, dropSpeed);


	}
	public void increaseRadius(){
		width += .1f;
		height += .1f;
	}
	public void decreaseRadius(){
		width -= .1f;
		height -= .1f;
	}
	public void increaseSpeed(){
		speed += .1f;
	}
	public void decreaseSpeed(){
		speed -= .1f;
	}
	public void increaseWidth(){
		width++;
	}
	public void decreaseWidth(){
		width--;
	}
	public void increaseHeight(){
		height++;
	}
	public void decreaseHeight(){
		height--;
	}

}
