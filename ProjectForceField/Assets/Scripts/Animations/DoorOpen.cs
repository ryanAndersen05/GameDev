using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
    public float goalOpenRotation;//The rotation of the door after it has been triggered to open
    public float openSmoothing = 3f;
    public Transform targetDoor;
    public GameObject[] deactivateDoorLogic;
    
    private float currentRotation;
    private Vector3 originalRotation;

    void Update()
    {
        Quaternion goalRotation = Quaternion.Euler(originalRotation.x, currentRotation, originalRotation.z);
        targetDoor.rotation = Quaternion.Lerp(targetDoor.rotation, goalRotation, openSmoothing * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        currentRotation = goalOpenRotation;
        enableDoors(false);
    }

    void OnTriggerExit(Collider collider)
    {
        currentRotation = originalRotation.y;
        enableDoors(true);
    }

    void enableDoors(bool isEnabled)
    {
        foreach(GameObject d in deactivateDoorLogic)
        {
            d.SetActive(isEnabled);
        }
    }

    void Awake()
    {
        originalRotation = targetDoor.eulerAngles;
    }
}
