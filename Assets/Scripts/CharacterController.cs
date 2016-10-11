using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float zmove = Input.GetAxis("Vertical");
        float xmove = Input.GetAxis("Horizontal");
		anim.SetFloat("zmove", zmove);
		anim.SetFloat("xmove", xmove);
        
		if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.LeftControl) && xmove!=0)
        {
            anim.SetBool("strafe", true);
        }
        else
        {
            if (zmove == 0 && xmove != 0)
            {
                transform.Rotate(new Vector3(0, xmove * 60 * Time.deltaTime));
            }
            anim.SetBool("strafe", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

    }
}
