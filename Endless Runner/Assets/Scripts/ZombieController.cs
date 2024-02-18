using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieController : MonoBehaviour
{
	[Header("Zombie Stats")]
	
	[SerializeField] private float zombieSpeed;
	[SerializeField] private float zombieHealth;
	
	[SerializeField] private bool isCrazy;
	[SerializeField] private float horizontalSpeed;
	[SerializeField] private float horizontalRange;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		ZombieMovement();
		if(transform.position.z <= -15.5f)
		{
			ZombieSpawnSystem.instance.StatsPleaseLock();
			DestroyZombie();
		}
	}
	
	private void ZombieMovement()
	{
		float horizontalMovement = 0;
		
		if(isCrazy)
		{
			horizontalMovement = Mathf.Cos(Time.time * horizontalSpeed) * horizontalRange;
		}
		
		Vector3 movement = new Vector3(horizontalMovement, 0, -1).normalized * zombieSpeed * Time.deltaTime;
		
		transform.Translate(movement.x,0, movement.z);
		transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -14.5f, 14.5f), transform.position.y, this.transform.position.z);

	}
	
	private void DestroyZombie()
	{
		ZombieSpawnSystem.instance.AddKill();
		Destroy(gameObject);
	}
	
	public void DamageZombie(float bulletDamage)
	{
		zombieHealth -= bulletDamage;
		
		if(zombieHealth <= 0)
		{
			DestroyZombie();
		}
	}
}
