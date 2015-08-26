using UnityEngine;
using System.Collections.Generic;

public class ConveyorBelt : MonoBehaviour {
	public Vector3 direction;
	public List<GameObject> objects;
	public static float speed = 1;
	public float speedGrowth;
	void Update(){
		foreach(GameObject obj in objects){
			obj.transform.Translate(direction * Time.deltaTime * speed);
		}
		speed += speedGrowth * Time.deltaTime;
	}
}
