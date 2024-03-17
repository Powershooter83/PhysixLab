using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody _rigidbody;

    private bool hasBeenPlaced = false;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hasBeenPlaced)
        {
            return;
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Right, UxrInputButtons.Button1))
        {
            hasBeenPlaced = true;
            _rigidbody.isKinematic = true;

            return;
        }

        var viewDirection = UxrAvatar.LocalAvatar.CameraForward;
        var input = UxrAvatar.LocalAvatarInput.GetInput2D(UxrHandSide.Left, UxrInput2D.Joystick);
        var inputVertical = UxrAvatar.LocalAvatarInput.GetInput1D(UxrHandSide.Left, UxrInput1D.Trigger);

        inputVertical -= UxrAvatar.LocalAvatarInput.GetInput1D(UxrHandSide.Left, UxrInput1D.Grip);


        var forwardDirection = Vector3.ProjectOnPlane(viewDirection, Vector3.up).normalized;
        var rightDirection = Vector3.Cross(Vector3.up, forwardDirection);
        var verticalMovement = Vector3.up * (inputVertical * moveSpeed * Time.deltaTime);
        var horizontalMovement = (forwardDirection * input.y + rightDirection * input.x).normalized *
                                 (moveSpeed * Time.deltaTime);

        _rigidbody.MovePosition(transform.position + verticalMovement + horizontalMovement);

        var rotation = UxrAvatar.LocalAvatarInput.GetInput2D(UxrHandSide.Right, UxrInput2D.Joystick).x *
                       rotationSpeed * Time.deltaTime;
        var deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        _rigidbody.MoveRotation(transform.rotation * deltaRotation);
    }
}