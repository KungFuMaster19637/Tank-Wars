using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private TankSO _tankSO;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cam;

    private float turnSmoothVelocity = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.Q))
        {
            //Rotate Left
            Debug.Log("rotating left");
            transform.Rotate(-Vector3.up * _tankSO.MaxRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Rotate right
            Debug.Log("rotating right");

            transform.Rotate(Vector3.up * _tankSO.MaxRotationSpeed * Time.deltaTime);
        }

        if (direction.magnitude >= 0.1f)
        {
            Debug.Log("here" + _rigidbody.velocity);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _tankSO.MaxRotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            float currentSpeed = _rigidbody.velocity.magnitude;
            float actualForce = _tankSO.MoveForce * (1 - currentSpeed / _tankSO.MaxMovementSpeed);
            Debug.Log(actualForce);
            _rigidbody.AddForce(moveDir.normalized * actualForce * _rigidbody.mass);
        }
    }
}
