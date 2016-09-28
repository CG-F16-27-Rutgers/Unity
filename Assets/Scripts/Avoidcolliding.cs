using UnityEngine;
using System.Collections.Generic;

public class Avoidcolliding : MonoBehaviour {
	private float threshold = 1f;
	private NavMeshAgent agent;
	private Rigidbody rb;
	private float distance;
	float force = 10;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Agent"))
		{
			distance = Vector3.Distance (agent.transform.position, obj.transform.position);
			if (distance < threshold) {
				Vector3 dir = obj.transform.position - transform.position;
				dir = -dir.normalized;
				rb.AddForce (dir * force);
			}
		}
	}
}

