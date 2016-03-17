using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillTarget : MonoBehaviour {
	public GameObject target;
	public ParticleSystem hitEffect;
	public GameObject killEffect;
	public float timeToSelect = 2.0f;
	public int score;
	public Text scoreText;

	private float countDown;

	void Start () {
		score = 0;
		countDown = timeToSelect;
		hitEffect.enableEmission = false;
		scoreText.text = "Score: 0";
	}

	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.position, camera.rotation *
		                   Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit) && (hit.collider.gameObject
		                                       == target)) {
			if (countDown > 0.0f) {
				// on target
				countDown -= Time.deltaTime;
				// print (countDown);
				hitEffect.transform.position = hit.point;
				hitEffect.enableEmission = true;
			} else {
				// killed
				Instantiate( killEffect, target.transform.position,
				            target.transform.rotation );
				score += 1;
				scoreText.text = "Score: " + score;
				countDown = timeToSelect;
				SetRandomPosition();
			}
		} else {
			// reset
			countDown = timeToSelect;
			hitEffect.enableEmission = false;
		}
	}

	void SetRandomPosition() {
		float x = Random.Range (-7.5f, 7.5f);
		float z = Random.Range (-7.5f, 7.5f);
		target.transform.position = new Vector3 (x, 0.0f, z);
	}
}