using UnityEngine;
using System.Collections.Generic;

public class Nazgul1 : MonoBehaviour
{
    private float minimumdis = 2;
    private NavMeshAgent agent;
    private float distance;
    private Vector3 Destination;
    private bool hadDestination;
    private bool escaped;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        escaped = false;
        hadDestination = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance < 0.5f)
        {
            agent.ResetPath();
            escaped = false;
            if (hadDestination)
            {
                agent.destination = Destination;
                hadDestination = false;
            }
        }

        foreach (GameObject nazgul in GameObject.FindGameObjectsWithTag("Nazgul"))
        {
            distance = Vector3.Distance(agent.transform.position, nazgul.transform.position);
            if (distance < minimumdis && !escaped)
            {
                float rand = Random.Range(1, 4);
                float x = rand + nazgul.transform.position.x;
                float y = nazgul.transform.position.y;
                float z = rand + nazgul.transform.position.z;
                Destination = agent.destination;
                hadDestination = true;
                agent.SetDestination(new Vector3(x, y, z));
                escaped = true;
            }

        }

    }


}