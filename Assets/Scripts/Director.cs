using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	public Camera camera;
	bool Click;
	NavMeshAgent agent;
	public Transform objectHit;
	public ArrayList agents;

	void Start()
	{
		Click = false;
		agents = new ArrayList();

	}
	void Update()
	{
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			objectHit = hit.transform;
			if (Input.GetMouseButtonDown(0))
			{
				//selecting agents
				if (objectHit.tag.ToString().Equals("Agent"))
				{
					print("Agent selected");
					objectHit.gameObject.GetComponent<AgentController> ().isNowSelected ();
					agents.Add(objectHit.gameObject);
					Click = true;
				}
				else if (Click == true)
				{
					print("Deploying!");
					foreach (GameObject obj in agents)
					{
						obj.GetComponent<AgentController>().Goto(hit);
						obj.GetComponent<AgentController>().enabled = true;
						obj.GetComponent<AgentController>().isNowNotSelected ();
					}
					agents.Clear();
					Click = false;
				}
			}
		}
	}

}
