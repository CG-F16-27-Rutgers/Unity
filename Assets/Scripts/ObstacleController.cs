using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    bool select;
	// Use this for initialization
	void Start () {
        select = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0)&&select==false)
            {
                if (hit.transform.gameObject.Equals(this.gameObject))
                {
                    select = true;
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && select == true && !hit.transform.gameObject.Equals(this.gameObject)) 
        {
            select = false;
        }
        if (select)
        {
            print("123");
            select = true;
            /*
            rb = this.gameObject.GetComponent<Rigidbody>();
            float moveHorizontal = 0;
            float moveVertical = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveHorizontal = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveHorizontal = 1;
            }
            Vector3 move = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);
            rb.AddForce(move);
            */
            Vector3 input = new Vector3(Input.GetAxis("Horizontal1"), 0.0f, Input.GetAxis("Vertical1"));
            input *= speed;
            this.gameObject.transform.position += input * Time.deltaTime;
        }
	}
}
