using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CherryCollector : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	public Text myCherriesCounter;
	int myCherriesCollected = 0;
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Cherry")) {
			Destroy(collision.gameObject);
			myCherriesCollected++;
			Debug.Log($"Cherries Collected {myCherriesCollected}");
			myCherriesCounter.text = $"Cherries Collected {myCherriesCollected}";
		}
	}
}
