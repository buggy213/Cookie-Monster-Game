using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {
	private float timer;
	public float interval;
	public GameObject[] foodStuffs;
	public float chanceOfCookie;
	public Transform[] spawnSpots;

	// index 0 of foodstuffs array must be cookie
	public void Update(){
		timer += Time.deltaTime;
		if(timer > interval){
			timer = 0;
			DecideFoodsToSpawn();
		}
	}
	void DecideFoodsToSpawn(){
		GameObject[] spawnFoods = new GameObject[spawnSpots.Length];
		float[] ranges = new float[spawnSpots.Length];
		for(int i = 0; i < foodStuffs.Length; i++){
			ranges[i] = (100 / foodStuffs.Length) * i;
				
		}
		ranges[spawnSpots.Length - 1] = 100;
		for(int i = 0; i < spawnFoods.Length; i++){
			if(Random.Range(0f, 100f) > chanceOfCookie){
				spawnFoods[i] = foodStuffs[0];
				continue;
			}
			float random = Random.Range(0f,100f);
			for(int index = 0; index < ranges.Length - 1; index++){
				if(random > ranges[index] && random < ranges[index + 1]){
					spawnFoods[i] = foodStuffs[index];
				}
			}
			
		}
		SpawnFood(spawnFoods);
	}
	void SpawnFood(GameObject[] foodsToSpawn){


		for(int i = 0; i < foodsToSpawn.Length; i ++){
			GameObject go = (GameObject)GameObject.Instantiate(foodsToSpawn[i], spawnSpots[i].position, Quaternion.identity);
			spawnSpots[i].parent.GetComponent<ConveyorBelt>().objects.Add(go);
		}
	}
}
