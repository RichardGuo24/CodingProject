using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float radius;
	[SerializeField] private ParticleSystem bulletParticleSystemPrefab;
	private float damage;
	
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject, 5f);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
		RaycastHit hit;
		
		if(Physics.SphereCast(transform.position, radius, new Vector3(0,0,1), out hit , .1f))
		{
			hit.transform.gameObject.GetComponent<ZombieController>().DamageZombie(damage);
			ParticleSystem bulletParticleSystem = Instantiate(bulletParticleSystemPrefab, transform.position, Quaternion.identity);
			Destroy(bulletParticleSystem.transform.gameObject,1f);
			Destroy(gameObject);
		}
	}
	
	public void SetDamage(float inputDamage)
	{
		damage = inputDamage;
	}
	
}
