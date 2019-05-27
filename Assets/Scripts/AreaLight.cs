using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLight : MonoBehaviour
{
    public GameManager gameManager;

    public Player player;

    public Light lt;

    public float lightDescend;

    private bool lightOn = false;

    private void TurnOn() {
        lt.intensity = 20;
    }

    private void Update()
    {
        if (!lightOn && gameManager.stage == 1)
        {
            Invoke("TurnOn", 1.5f);
            lightOn = true;
        }

        transform.position = player.transform.position + new Vector3(0, 3, 0);

        if (lightOn && lt.spotAngle > 30.0f && !player.Finished)
        {
            lt.spotAngle = lt.spotAngle - lightDescend;
        }

        if (player.Finished)
        {
            lt.spotAngle = 120f;
            lt.intensity = 15;
            lt.range = 8;
        }
    }
}
