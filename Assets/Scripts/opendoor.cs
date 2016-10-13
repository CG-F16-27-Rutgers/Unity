using UnityEngine;
using System.Collections;

public class opendoor : MonoBehaviour
{
    float smooth = 1.0f;
    public float DoorOpenAngle;
    float DoorCloseAngle = 0.0f;
    bool open;
    bool enter;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Agent")
        {
            enter = true;
            print("open");
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agent")
        {
            enter = false;
            print("close");
        }
    }

    void Update()
    {
        if (enter == true)
        {
            print("if(open)");
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }
        if (enter == false)
        {
            print("if(open is false)");
            var target = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }

        //if (enter == true)
        //{
        //    print("if(enter)");
        //    open = !open;
        //    print(open);
        //}
    }
}