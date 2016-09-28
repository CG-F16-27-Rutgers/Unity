using UnityEngine;
using System.Collections;

public class opendoor : MonoBehaviour
{
    float smooth = 2.0f;
    public float DoorOpenAngle;
    float DoorCloseAngle = 0.0f;
    bool open;
    bool enter;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
            print("open");
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
            print("close");
        }
    }

    void Update()
    {
        if (open == true)
        {
            print("if(open)");
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }

        if (enter == true)
        {
            print("if(enter)");
            open = !open;
            print(open);
        }
    }
}