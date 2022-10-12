using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceOfCube;

    private Vector3 startPosition;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        Move();
        CheckDistance();
    }

    private void Move()
    {
        if (gameObject.activeSelf)
        {
            rb.velocity = Vector3.forward * speed;
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(startPosition, transform.position) > distanceOfCube)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDistanceOfCube(float distanceOfCube)
    {
        this.distanceOfCube = distanceOfCube;
    }

    public void SetStartPosition()
    {
        startPosition = transform.position;
    }
}
