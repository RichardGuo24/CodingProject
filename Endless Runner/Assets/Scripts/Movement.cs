using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
	[SerializeField] private float speed;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		MovementFunction();
	}
	
	
	private void MovementFunction()
	{
		float horizontalInput = 0f;
		float verticalInput = 0f;

		if (Input.GetKey(KeyCode.D))
			horizontalInput += 1f;
		if (Input.GetKey(KeyCode.A))
			horizontalInput -= 1f;
 		if (Input.GetKey(KeyCode.W))
			verticalInput += 1f;
		if (Input.GetKey(KeyCode.S))
			verticalInput -= 1f;
			

		Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * speed * Time.deltaTime;

		transform.Translate(movement);
		
		transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -14.5f, 14.5f), transform.position.y, Mathf.Clamp(this.transform.position.z, -24f, -16f));	
	}
}
