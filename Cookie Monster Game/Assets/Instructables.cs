using UnityEngine;
using System.Collections;

public class Instructables : MonoBehaviour {
	public int index;
	void Start(){
		Time.timeScale = 0;
	}
	public void MovePage(int amount){
		transform.parent.GetChild(index + amount).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
	public void Finish(){
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}
}
