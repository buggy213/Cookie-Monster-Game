using UnityEngine;
using System.Collections;

public class CountdownToVictory : MonoBehaviour {
	public float secsTillVic;
	public UnityEngine.UI.Text text;
	// Update is called once per frame
	void Update () {
		text.text = "Seconds until victory: " + (secsTillVic - Time.time).ToString("f2");
		if(secsTillVic - Time.time <= 0){
			Application.LoadLevel("Win");
		}
	}
}
