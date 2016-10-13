using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class walkrun : MonoBehaviour {
    Animator anim;
    NavMeshAgent agent;
    CharacterController cc;

    bool walk = true;

    public Text StatusText;
    // Use this for initialization
    void Start () {
        GameObject animator = GameObject.FindWithTag("Agent");

        anim = animator.GetComponent<Animator>();
        agent = animator.GetComponent<NavMeshAgent>();
        cc = GameObject.FindObjectOfType<CharacterController>();
    }   
	
	// Update is called once per frame
	void Update () {
       

        anim.SetBool("run", !walk);

        bool shouldMove = cc.velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("move", shouldMove);

        if (walk == true)
        {
            StatusText.text = "Status:walk";
            agent.speed = 3.5f;
        }
        else
        {
            StatusText.text = "Status:run";
            agent.speed = 5;
            if(shouldMove==false)
                anim.SetBool("run", false);
        }
    }

    public void setwalkrun()
    {
        walk = !walk;
  
    }
}
