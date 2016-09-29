using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	public Camera camera;
	bool Click1;
    bool Click2;
    NavMeshAgent agent;
	public Transform objectHit;
	public ArrayList agents;
    public ArrayList nazguls;

    void Start()
	{
		Click1 = false;
        Click2 = false;
        agents = new ArrayList();
        nazguls = new ArrayList();

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
					Click1 = true;
				}
				else if (Click1 == true)
				{
					print("Deploying!");
					foreach (GameObject obj in agents)
					{
						obj.GetComponent<AgentController>().Goto(hit);
						obj.GetComponent<AgentController>().enabled = true;
						obj.GetComponent<AgentController>().isNowNotSelected ();
					}
					agents.Clear();
					Click1 = false;
				}
                //selecting nazguls
                if (objectHit.tag.ToString().Equals("Nazgul"))
                {
                    print("Nazgul selected");
                    objectHit.gameObject.GetComponent<AgentController>().isNowSelected();
                    nazguls.Add(objectHit.gameObject);
                    Click2 = true;
                }
                else if (Click2 == true)
                {
                    print("Deploying!");
                    foreach (GameObject obj in nazguls)
                    {
                        obj.GetComponent<AgentController>().Goto(hit);
                        obj.GetComponent<AgentController>().enabled = true;
                        obj.GetComponent<AgentController>().isNowNotSelected();
                    }
                    nazguls.Clear();
                    Click2 = false;
                }
            }
            if (Click1 == true && Input.GetMouseButtonDown(1))
            {
                print("Deploying!");
                foreach (GameObject obj in agents)
                {
                    obj.GetComponent<AgentController>().Goto(hit);
                    obj.GetComponent<AgentController>().enabled = true;
                    obj.GetComponent<AgentController>().isNowNotSelected();
                }
                agents.Clear();
                Click1 = false;
            }

        }
    }

}
