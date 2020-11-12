using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float steeringSpeed = 10f;
    [SerializeField] float xClampRange = 5.35f;
    [SerializeField] float yClampRange = 4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -7f;
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controlRollFactor = -5f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessSteering();
        ProcessRotation();
    }

    private void ProcessSteering()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * steeringSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        newXPos = Mathf.Clamp(newXPos, -xClampRange, xClampRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * steeringSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        newYPos = Mathf.Clamp(newYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
