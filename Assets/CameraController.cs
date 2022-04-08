using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform myPlayer;
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		this.transform.position = new Vector3(myPlayer.position.x, myPlayer.position.y, transform.position.z);
	}
}
