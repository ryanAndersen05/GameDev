using UnityEngine;
using System.Collections;

public class GrabMechanics : MonoBehaviour {
    Transform grabbedObject;
    bool grabInputDown;
    Vector3 offset;

    
    void OnTriggerEnter(Collider collider)
    {
        grabbedObject = collider.transform;
        print("Hello there");
    }

    void OnTriggerExit(Collider collider)
    {
        grabbedObject = null;
    }

    public void grab(bool grabInput)
    {
        grabInputDown = grabInput;
        if (grabInput && grabbedObject != null)
        {
            print("Hello there");
            offset = -this.transform.position + grabbedObject.position;
        }
    }

    void Update()
    {
        print(grabInputDown);
        if (grabInputDown && grabbedObject != null)
        {
            grabbedObject.transform.position = this.transform.position + offset;
        }
    }

    public bool getIsGrabbing()
    {
        return grabInputDown && grabbedObject != null;
    }
}
