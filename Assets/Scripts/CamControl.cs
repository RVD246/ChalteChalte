using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float sensitivity;

    public float camdistance;

    public Transform playertransform;
    public Transform player;

    public Vector2 VerticalClamps;

    float Horizontal;
    float Vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vertical += Input.GetAxis("Mouse Y") * sensitivity;
        Horizontal += Input.GetAxis("Mouse X") * sensitivity;

        Vertical = Mathf.Clamp(Vertical, VerticalClamps.x, VerticalClamps.y);

        transform.rotation = Quaternion.Euler(-Vertical, Horizontal, 0);
        player.transform.rotation = Quaternion.Euler(0, Horizontal, 0);

        transform.position = playertransform.position - transform.forward * camdistance;
    }
}
