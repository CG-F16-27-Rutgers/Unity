using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    float Speed = 0.5f;
    Camera defaultCam;
    bool isEnabled;

    // Use this for initialization
    void Start()
    {
        defaultCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(-defaultCam.transform.up * Speed * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(defaultCam.transform.right * Speed * Input.GetAxis("Horizontal"));
        }
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0)
        {
            transform.Translate(defaultCam.transform.forward * Speed * 0.5f);
        }
        else if (d < 0)
        {
            transform.Translate(-defaultCam.transform.forward * Speed * 0.5f);
        }

    }
}
