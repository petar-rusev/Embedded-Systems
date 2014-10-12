using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;

public class ArduinoMovement : MonoBehaviour
{

    private Vector3 position;
    private float speed = 10;
    private RaycastHit hit;
    Vector3 lookTarget;

    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip fire;
    public AnimationClip die;
    //Arduino Control
    ArduinoTalk arduino = new ArduinoTalk("COM3", 9600);
   
    //TODO:Health system
    private float health = 65000;

    void Start()
    {
        arduino.OpenPort(arduino.Sp,20);
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        ArduinoMoves(arduino.ReadPortValue(arduino.Sp));
        //Moving & Firing
        if (horizontalMove != 0 || verticalMove != 0)
        {
            MoveWASD(horizontalMove, verticalMove);
            Rotation();
        }
        // Idle
        else
        {
            // Fire
            if (Input.GetMouseButton(0))
            {
                //TODO: Mouse Button Shoot the enemy
                animation.CrossFade(fire.name);
            }
            else
            {
                animation.CrossFade(idle.name);
            }

            Rotation();

        }
        //Dead
        if (health <= 0)
        {
            animation.CrossFade(die.name);
        }

    }

    private void Rotation()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;

        }
        transform.LookAt(lookTarget);
    }

    public void MoveWASD(float horizontalMove, float verticalMove)
    {
        transform.position += (Vector3.forward * (verticalMove) + Vector3.right * horizontalMove) * Time.deltaTime * speed;

        animation.CrossFade(run.name);
    }
    //Arduino control method
    public void ArduinoMoves(int direction)
    {
        if (direction == 1)
        {
            transform.position += (Vector3.right * speed * Time.deltaTime);
            animation.Play(run.name);

        }
        if (direction == 2)
        {
            transform.position += (Vector3.left * speed * Time.deltaTime);
            animation.Play(run.name);
        }
        if (direction == 3)
        {
            transform.position += (Vector3.forward * speed * Time.deltaTime);
            animation.Play(run.name);
        }
        if (direction == 4)
        {
            transform.position += (Vector3.back * speed * Time.deltaTime);
            animation.Play(run.name);
        }
        
    }
}
    