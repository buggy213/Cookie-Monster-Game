using UnityEngine;
using System.Collections;

public class AutoTiler : MonoBehaviour {
	public GameObject tileObject;
	public Camera camera;
	private Vector3 topLeft;
	private Vector3 bottomRight;

	// Use this for initialization
	void Start () {

		FindCorners();
		Tile();
	}
	void Tile(){
		for(int x = 0; x < Mathf.Ceil(bottomRight.x - topLeft.x) + 1; x++){
			for(int y = 0; y < Mathf.Ceil(topLeft.y - bottomRight.y) + 1; y++){
				GameObject.Instantiate(tileObject, (new Vector3(x,0,10) + topLeft) - new Vector3(0,y,0), Quaternion.identity);
			}
		}
	}
	void FindCorners(){
		topLeft = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
		bottomRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
	}
}
