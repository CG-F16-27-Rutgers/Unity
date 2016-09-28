using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

	NavMeshAgent agent;


	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();

	}

	void Update () 
	{
//		if(Input.GetMouseButtonDown (0))
//		{
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit;
//
//			if(Physics.Raycast(ray, out hit))
//			{
//				Goto(hit);
//			}
//		}

	}


	public void isNowSelected() {
		Renderer rend = GetComponent<Renderer> ();
		rend.material.color = Color.grey;
	}
		
	public void isNowNotSelected() {
		Renderer rend = GetComponent<Renderer> ();
		rend.material.color = Color.white;
	}

	public void Goto(RaycastHit hit)
	{
		agent.SetDestination (hit.point);
	}


}
