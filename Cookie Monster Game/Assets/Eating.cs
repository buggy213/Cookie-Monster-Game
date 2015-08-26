using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Eating : MonoBehaviour {
	public KeyCode eatCode;
	List<GameObject> food;
	static KeyCode[] keys = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
	// Update is called once per frame

	void Start(){
		food = new List<GameObject>();
	}
	void Update () {
		if(Input.GetKeyDown(eatCode)){
			if(!(food.Count == 0)){
				EatFood();
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Food"){
			food.Add(other.gameObject);
		}
	}
	void EatFood(){
		if(food[0].name.Contains("Cookie")){
			GameObject foodToDestroy = food[0];
			food.RemoveAt(0);
			transform.parent.GetComponent<ConveyorBelt>().objects.RemoveAt(0);
			GameObject.Destroy(foodToDestroy);
		}
		else{
			Application.LoadLevel("LosePoo");
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(food[0].name.Contains("Cookie")){
			Application.LoadLevel("LoseCookie");
		}
		else{
			Application.LoadLevel("LosePoo");
		}
	}
}
