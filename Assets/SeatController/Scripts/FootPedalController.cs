using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPedalController : MonoBehaviour
{

    // Use this for initialization
    public GameObject UpperPedal, LowerPedal;

    public float movementSpeed = 5f;
    public float turnSpeed = 90f;
    void Start()
    {
        FirstPersonController fpsController = GetComponent<FirstPersonController>();
        fpsController.m_WalkSpeed = movementSpeed;
        fpsController.turnSpeed = turnSpeed;
    }
    private float vertical, horizontal = 0.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 upperPedalRot = UpperPedal.transform.rotation.eulerAngles; // Z: 162.2 -> 175.2
        Vector3 lowerPedalRot = LowerPedal.transform.rotation.eulerAngles; // Z: -166 -> -152


        if (vertical > 0.0f)
        {
            vertical -= 0.2f;
			movementSpeed *= vertical;
        }

		else
			vertical = 0.0f;

		// If upper pedal is pressed:
        if (upperPedalRot.z > 170.0f)
        {
            vertical = 1.0f;
			movementSpeed = 5.0f;
        }
        //Debug.Log(vertical);
        if (Input.GetKey(KeyCode.S))
        {
            //vertical -= 1.0f;
        }

        CustomInput.SetAxis("Vertical", vertical);
        CustomInput.SetAxis("Horizontal", horizontal);
    }

	void NowCalibrated()
	{
		Debug.Log("MPU now calibrated!");
	}
}
