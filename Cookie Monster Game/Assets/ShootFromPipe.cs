using UnityEngine;
using System.Collections;

public class ShootFromPipe : MonoBehaviour {
	public GameObject foodInSteamBlast;
	public GameObject previousFoodInSteamBlast;
	public KeyCode key;
	public float forceMultiplier;
	public ConveyorBelt cb;
	private float timer = 0f;
	private float loseTime = .25f;
	bool losing;
	public void Update(){
		if(losing){
			timer += Time.deltaTime;
		}
		if(timer >= loseTime){
			Application.LoadLevel("LoseCookie");
		}
		if(Input.GetKeyDown(key)){
			transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
			if(foodInSteamBlast != null){
				if(foodInSteamBlast.name.Contains("Cookie")){
					losing = true;
				}
				foodInSteamBlast.GetComponent<Rigidbody2D>().AddForce((Vector2)((foodInSteamBlast.transform.position - transform.position) * forceMultiplier), ForceMode2D.Impulse);
				cb.objects.Remove(foodInSteamBlast);
			}
		}

	}
	public void InTrigger(GameObject go){
		foodInSteamBlast = go;
	}

}
