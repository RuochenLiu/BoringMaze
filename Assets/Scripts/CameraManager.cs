using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Player player;

    public float cameraHeight;

    public float cameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, cameraHeight, -cameraDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Finished) {
            Vector3 tmp = transform.rotation.eulerAngles;
            tmp.x = 20.0f;
            transform.rotation = Quaternion.Euler(tmp);

            cameraHeight = 0.8f;
            cameraDistance = 1.2f;
        }

        transform.position = player.transform.position + new Vector3(0, cameraHeight, -cameraDistance);
    }
}
