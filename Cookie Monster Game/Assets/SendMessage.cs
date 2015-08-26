using UnityEngine;
using System.Collections;

public class SendMessage : MonoBehaviour {
	public bool flag = false;
	public float decayTime = .75f;
	float timer;
	void OnTriggerStay2D(Collider2D other){
		transform.parent.GetComponent<ShootFromPipe>().InTrigger(other.gameObject);

	}
	void Update(){
		if(GetComponent<SpriteRenderer>().enabled){ timer += Time.deltaTime; }
		if(timer > decayTime) { timer = 0; GetComponent<SpriteRenderer>().enabled = false; } 
	}


}
