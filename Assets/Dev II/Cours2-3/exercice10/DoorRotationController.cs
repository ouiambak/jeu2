using UnityEngine;
using System.Collections;

public class DoorRotationController : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;

    public float closedAngle = 0f;
    public float openAngle = 90f;
    public float rotationSpeed = 90f;

    private bool isOpen = false; 
    private bool isRotating = false; 

    void OnEnable()
    {
        ButtonEvents.OnDoorOpenRequested += ToggleDoor;
    }

    void OnDisable()
    {
        ButtonEvents.OnDoorOpenRequested -= ToggleDoor;
    }
    void ToggleDoor()
    {
        if (!isRotating)
        {
            if (!isOpen)
            {
                StartCoroutine(RotateDoors(closedAngle, openAngle));
                isOpen = true;
            }
            else
            {
                StartCoroutine(RotateDoors(openAngle, closedAngle));
                isOpen = false;
            }
        }
    }

    IEnumerator RotateDoors(float startAngle, float endAngle)
    {
        isRotating = true;
        float elapsed = 0f;
        float totalTime = Mathf.Abs(endAngle - startAngle) / rotationSpeed;

        while (elapsed < totalTime)
        {
            elapsed += Time.deltaTime;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, elapsed / totalTime);

            if (leftDoor != null)
                leftDoor.localEulerAngles = new Vector3(0, -currentAngle, 0);

            if (rightDoor != null)
                rightDoor.localEulerAngles = new Vector3(0, currentAngle, 0);

            yield return null;
        }

        if (leftDoor != null)
            leftDoor.localEulerAngles = new Vector3(0, -endAngle, 0);
        if (rightDoor != null)
            rightDoor.localEulerAngles = new Vector3(0, endAngle, 0);

        isRotating = false;
    }
}
