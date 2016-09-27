using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {

	float Speed = 0.5f;
	Camera defaultCam;
	bool isEnabled;

	// Use this for initialization
	void Start () {
		defaultCam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") != 0)
		{
			transform.Translate(-defaultCam.transform.forward * Speed * Input.GetAxis("Vertical"));
		}
		if (Input.GetAxis("Horizontal") != 0)
		{
			transform.Translate(-defaultCam.transform.right * Speed * Input.GetAxis("Horizontal"));
		}
		if (Input.GetKey(KeyCode.E))
		{
			transform.Translate(defaultCam.transform.up * Speed*0.5f);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			transform.Translate(-defaultCam.transform.up * Speed*0.5f);
		}
	}
}