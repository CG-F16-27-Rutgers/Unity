﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	Animator anim;
	NavMeshAgent agent;
	Vector2 smoothDeltaPosition = Vector2.zero;
	public Vector2 velocity = Vector2.zero;
    bool traversingLink = false;
    OffMeshLinkData currLink;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>(); 
		// Don’t update position automatically
		agent.updatePosition = false;
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;



        // Update animation parameters
        anim.SetBool("move", shouldMove);
        anim.SetFloat("xmove", velocity.x);
        anim.SetFloat("zmove", velocity.y);

        if (agent.isOnOffMeshLink)
        {
            if (!traversingLink)
            {
                agent.Stop();
                anim.Play("Walk Jump");
                //anim.CrossFade("Walk Jump", 0.1f, PlayMode.StopAll);
                currLink = agent.currentOffMeshLinkData;
                traversingLink = true;
            }
            var tlerp = GetComponent<animation>["Walk Jump"].normalizedTime;
            var newPosition = Vector3.Lerp(currLink.startPos, currLink.endPos, smooth);
            newPosition.y += 2f * Mathf.Sin(Mathf.PI * smooth);
            transform.position = newPosition;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk Jump"))
            {
                Debug.Log("should be at other side of navMesh");
                transform.position = currLink.endPos;
                traversingLink = false;
                agent.CompleteOffMeshLink();
                agent.Resume();
            }

        }
    }


    void OnAnimatorMove()
	{
		// Update position to agent position
		transform.position = agent.nextPosition;
	}
}