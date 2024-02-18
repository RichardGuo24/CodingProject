using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ZombieSpawnSystem : MonoBehaviour
{
	public static ZombieSpawnSystem instance;
	
	
	[SerializeField] private GameObject normalZombiePrefab;
	[SerializeField] private GameObject crazyZombiePrefab;
	[SerializeField] private GameObject bossZombiePrefab;
	[SerializeField] private TextMeshProUGUI waveText;
	[SerializeField] private TextMeshProUGUI kills;

	
	
	
	private int wave;
	private int numOfKills;
	private int totalKills;
	//Only temp
	private bool statsLock;
	
	//private List<GameObject> zombieList = new List<GameObject>();
	
	// Start is called before the first frame update
	void Start()
	{
		instance = this;
		
		statsLock = false;
		numOfKills = 0;
		wave = 0;
		StartNewWave();
		//FillList();
	}

	// Update is called once per frame
	void Update()
	{
		if(wave == numOfKills && wave != 0)
		{
			StartNewWave();
		}
		waveText.text = "Wave: " + wave.ToString();
		kills.text = "Kills: " + totalKills.ToString();
		
	}
	
	void StartNewWave()
	{
		numOfKills = 0;
		if(statsLock != true)
		{
			wave++;
			StartCoroutine(SpawnEnemy());
		}
		//FillList();
		//SpawnNewWave();
	}
	
	public void AddKill()
	{
		numOfKills++;
		if(statsLock != true)
		{
			totalKills++;	
		}
	}
	
	
	IEnumerator SpawnEnemy()
	{
		if(wave % 5 == 0)
		{
			Instantiate(bossZombiePrefab, new Vector3(0,.5f, Random.Range(34, 42)), Quaternion.identity);
		}
		for(int i = 0; i < wave; i++)
		{
			if(Random.value >= .75)
			{
				Instantiate(crazyZombiePrefab, new Vector3(Random.Range(-14,14),.5f, Random.Range(34, 42)), Quaternion.identity);
			}else
			{
				Instantiate(normalZombiePrefab, new Vector3(Random.Range(-14,14),.5f, Random.Range(34, 42)), Quaternion.identity);
			}
			yield return new WaitForSeconds(1f);
		}
		
	}
	
	public void StatsPleaseLock()
	{
		statsLock = true;
	}
	/*public void CheckIfZombieListEmpty()
	{
		zombieList.RemoveAt(0);
	
		if (zombieList.Count == 0)
		{
	 		StartNewWave();
		}
	}
	*/
	/*
	void FillList()
	{
		for(int i = 0; i < wave; i++)
		{
			if(Random.value <= .75)
			{
				zombieList.Add(normalZombiePrefab);
			}else
			{
				zombieList.Add(crazyZombiePrefab);
			}
		}
	}
	*/
	/*
	void SpawnNewWave()
	{
		int count = zombieList.Count;
		for(int i = 0; i < count; i++)
		{
			StartCoroutine(SpawnEnemy(i));
		}
	}
	
	IEnumerator SpawnEnemy(int index)
	{
		//No clue how this works
		yield return new WaitForSeconds(index * 1f);
		
		Debug.Log(index);
		
		Instantiate(zombieList[index], new Vector3(Random.Range(-14,14),.5f, Random.Range(34, 42)), Quaternion.identity);
	}
	*/
}
