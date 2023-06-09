using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private float leftLimit;
    private float rightLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.x = player.position.x;
            //cameraPosition.x = Mathf.Clamp(mario.position.x, leftLimit, rightLimit);
            transform.position = cameraPosition;
        }
    }
}
