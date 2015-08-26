using UnityEngine;
using System.Collections;

public class LoseGame : MonoBehaviour {
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.name.Contains("Cookie")){
			transform.parent.GetComponent<Lose>().LoseGame();
			print("out shoot");

		}
	}

}
