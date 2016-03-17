using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {
	void Start () {
		StartCoroutine (RePositionWithDelay());
	}

	IEnumerator RePositionWithDelay() {
		while (true) {
			SetRandomPosition();
			yield return new WaitForSeconds (5);
		}
	}

	void SetRandomPosition() {
		float x = Random.Range (-7.5f, 7.5f);
		float z = Random.Range (-7.5f, 7.5f);
		Debug.Log ("X,Z: " + x.ToString("F2") + ", " +
		           z.ToString("F2"));
		transform.position = new Vector3 (x, 0.0f, z);
	}
}