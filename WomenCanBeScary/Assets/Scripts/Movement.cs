using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float lookSpeed = 2.0f;

    private Vector3 _moveDirection = Vector3.zero;

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;

    Rigidbody rb;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirectionForward = transform.forward * vertical;
        Vector3 moveDirectionSideways = transform.right * horizontal;

        _moveDirection = (moveDirectionForward + moveDirectionSideways) * speed;

        // Rotación de la cámara
        _rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        _rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationY = Mathf.Clamp(_rotationY, -45, 45);

        transform.localRotation = Quaternion.Euler(0, _rotationX, 0);

        cam.transform.localRotation = Quaternion.Euler(-_rotationY, _rotationX, 0);

        // Movimiento del jugador
        rb.MovePosition(_moveDirection * speed * Time.deltaTime);
    }
}
