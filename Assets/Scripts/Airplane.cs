﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    private GamePlay gamePlay;

    [SerializeField] float flightSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] TouchJoystick joystick;
    private bool startingTurnComplete = false;

    private float flightDirection;
    private Rigidbody2D rb2D;

	// Use this for initialization
	void Start ()
    {
        gamePlay = FindObjectOfType<GamePlay>();
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<TouchJoystick>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, flightSpeed);

        rb2D.AddForce(transform.right * flightSpeed);

        if (startingTurnComplete)
        {
            if (Input.GetMouseButton(0))
            {
                flightDirection = Mathf.Atan2(joystick.joystickDirection.y, joystick.joystickDirection.x) * Mathf.Rad2Deg;
                TurnAirplane(flightDirection);
            }
        }
    }

    public IEnumerator StartingTurn ()
    {
        for (float flightDirection = 90; flightDirection <= 270; flightDirection += Time.deltaTime * turnSpeed)
        {
            TurnAirplane(flightDirection);
            yield return null;
        }

        joystick.GetComponent<ETCJoystick>().visible = true;
        startingTurnComplete = true;
    }

    void TurnAirplane (float flightDirection)
    {
        Quaternion qt = Quaternion.AngleAxis(flightDirection, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * turnSpeed);
    }

    //Collisions
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
}
