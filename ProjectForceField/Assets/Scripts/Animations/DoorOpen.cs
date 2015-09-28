using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
    public float goalOpenRotation;//The rotation of the door after it has been triggered to open
    public float openSmoothing = 3f;
    public Transform targetDoor;
    public DoorOpen otherSide;
    
    private float currentRotation;
    private Vector3 originalRotation;
    private bool isOpen;

    void Update()
    {
        if (otherSide.isOpen)
        {
            return;
        }
        Quaternion goalRotation = Quaternion.Euler(originalRotation.x, currentRotation, originalRotation.z);
        float offsetRotation = openSmoothing * Time.deltaTime;
        if (Mathf.Abs(originalRotation.y - currentRotation) < .01)
        {
            offsetRotation /= 3;
        }
        targetDoor.rotation = Quaternion.Lerp(targetDoor.rotation, goalRotation, offsetRotation);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!otherSide.isOpen)
        {
            currentRotation = goalOpenRotation;
        }
        else
        {
            currentRotation = otherSide.goalOpenRotation;
        }
       
        isOpen = true;
    }

    void OnTriggerExit(Collider collider)
    {
        currentRotation = originalRotation.y;
       
        isOpen = false;
    }

   

    void Awake()
    {
        originalRotation = targetDoor.eulerAngles;
    }

 
}
