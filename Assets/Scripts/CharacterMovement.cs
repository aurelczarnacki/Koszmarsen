using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Singleton
    public static CharacterMovement Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public FloatingJoystick _joystick;
    public float moveSpeed;
    public float maxDistance = 0.5f;
    public Collider cameraCollider;
    public Transform cameraTransform;
    public List<ParticleSystem> fallingSmokes;

    private Vector3 moveVector;

    private void Update()
    {
        Move();
        Rotate();
        MoveCamera();
    }
    private void ChangeColor(Color color)
    {
        foreach(ParticleSystem particleSystem123 in fallingSmokes)
        {
            ParticleSystem.MainModule mainModule = particleSystem123.main;
            mainModule.startColor = color;
        }
    }
    public void ChangePlayerSpeedCoroutine(float speedMultiplier, float duration)
    {
        StartCoroutine(ChangePlayerSpeed(speedMultiplier, duration));
    }
    private IEnumerator ChangePlayerSpeed(float speedMultiplier, float duration)
    {
        moveSpeed *= speedMultiplier;
        ChangeColor(new Color(0.5294f, 0.8078f, 0.9804f));

        yield return new WaitForSeconds(duration);

        moveSpeed /= speedMultiplier;
        ChangeColor(Color.white);
    }
    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = _joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = _joystick.Vertical * moveSpeed * Time.deltaTime;
        Vector3 currentPosition = transform.position;

        currentPosition += moveVector;

        Vector3 closestPointOnCollider = cameraCollider.ClosestPoint(currentPosition);

        if (Vector3.Distance(currentPosition, closestPointOnCollider) > 0.1f)
        {
            currentPosition = closestPointOnCollider + (currentPosition - closestPointOnCollider).normalized * 0.1f;
        }

        transform.position = currentPosition;
    }

    private void Rotate()
    {
        Vector2 joystickInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if (joystickInput.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(joystickInput.x, joystickInput.y) * Mathf.Rad2Deg;

            float reversedAngle = angle + 180f;

            Quaternion targetRotation = Quaternion.Euler(0, reversedAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
    void MoveCamera()
    {
        Vector3 currentCameraPosition = cameraTransform.position;

        currentCameraPosition.x += moveVector.x;
        currentCameraPosition.z += moveVector.z;

        Vector3 closestPointOnCollider = cameraCollider.ClosestPoint(currentCameraPosition);
        closestPointOnCollider.y = 0;

        Vector3 offsetFromCollider = currentCameraPosition - closestPointOnCollider;

        if (offsetFromCollider.magnitude > maxDistance)
        {
            offsetFromCollider = offsetFromCollider.normalized * maxDistance;

            cameraTransform.position = closestPointOnCollider + offsetFromCollider;
        }
        else
        {
            cameraTransform.position = currentCameraPosition;
        }
    }
}
