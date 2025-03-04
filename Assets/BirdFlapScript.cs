using UnityEngine;

public class BirdFlap : MonoBehaviour
{
    public Transform leftWing;  // Assign the left wing GameObject in the Inspector
    public Transform rightWing; // Assign the right wing GameObject in the Inspector
    public float flapAngle = 30f; // Angle to rotate the wings
    public float flapSpeed = 10f; // Speed of the flapping motion

    private Quaternion leftWingStartRotation; // Default rotation of the left wing
    private Quaternion rightWingStartRotation; // Default rotation of the right wing
    private bool isFlapping = false;

    void Start()
    {
        // Save the starting rotations of the wings
        leftWingStartRotation = leftWing.rotation;
        rightWingStartRotation = rightWing.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlapping = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlapping = false;
        }

        // Rotate the wings based on the flapping state
        if (isFlapping)
        {
            FlapWings();
        }
        else
        {
            ResetWings();
        }
    }

    void FlapWings()
    {
        // Rotate the left wing upward
        leftWing.rotation = Quaternion.Euler(0, 0, flapAngle);

        // Rotate the right wing downward
        rightWing.rotation = Quaternion.Euler(0, 0, -flapAngle);
    }

    void ResetWings()
    {
        // Smoothly reset the wings to their default rotation
        leftWing.rotation = Quaternion.Lerp(leftWing.rotation, leftWingStartRotation, flapSpeed * Time.deltaTime);
        rightWing.rotation = Quaternion.Lerp(rightWing.rotation, rightWingStartRotation, flapSpeed * Time.deltaTime);
    }
}