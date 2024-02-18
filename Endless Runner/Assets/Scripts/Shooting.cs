using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	[Header("Gunstats")]
	[SerializeField] private float damage;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private ParticleSystem muzzleFlashPrefab;
	
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}
	
	private void Fire()
	{
		GameObject bulletGameObject = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + .015f, transform.position.z + 1.75f), Quaternion.identity);
		ParticleSystem muzzleFlash = Instantiate(muzzleFlashPrefab, new Vector3(transform.position.x, transform.position.y + .015f, transform.position.z + 1.75f), Quaternion.identity);
		Destroy(muzzleFlash.transform.gameObject,1f);
		bulletGameObject.GetComponent<Bullet>().SetDamage(damage);
		
	}
}
