using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public Animator anim;

    public float Speed = 0.01f;

    public Rigidbody Rg;

    public bool Finished = false;

    private bool canMove = false;

    private bool gameStart = false;

    private float startTime;

    void Update()
    {
        if (!gameStart && gameManager.stage == 1)
        {
            startTime = Time.time;
            gameStart = true;
        }

        if (gameStart)
        {
            Rg.velocity = Vector3.zero;
            Rg.angularVelocity = Vector3.zero;

            // Frozen till maze completed
            if (!canMove)
            {
                if ((Time.time - startTime) > 1.5f)
                {
                    canMove = true;
                }
            }

            // Game Finished
            if (transform.position.x >= 4 && transform.position.z <= -4)
            {
                Finished = true;
                transform.rotation = new Quaternion(0, 180, 0, 0);
                anim.SetBool("isDancing", true);
                return;
            }

            if (!Finished && canMove)
            {
                //Walk Downwards
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                    transform.position += new Vector3(0, 0, -Speed);
                    anim.SetBool("isWalking", true);
                }
                //Walk Upwards
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.position += new Vector3(0, 0, Speed);
                    anim.SetBool("isWalking", true);
                }
                //Walk rightwards
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Vector3 tmp = transform.rotation.eulerAngles;
                    tmp.y = 90.0f;
                    transform.rotation = Quaternion.Euler(tmp);
                    transform.position += new Vector3(Speed, 0, 0);
                    anim.SetBool("isWalking", true);
                }
                //Walk leftwards
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Vector3 tmp = transform.rotation.eulerAngles;
                    tmp.y = -90.0f;
                    transform.rotation = Quaternion.Euler(tmp);
                    transform.position += new Vector3(-Speed, 0, 0);
                    anim.SetBool("isWalking", true);
                }
                else
                {
                    anim.SetBool("isWalking", false);
                }
            }
        }
    }
}
