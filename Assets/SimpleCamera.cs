using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public float xDelta = 0.01f;
    public float yDelta = 0.01f;
    public float zDelta = 0.01f;

    public float mousexDelta = 0.5f;
    public float mouseyDelta = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + xDelta*Input.GetAxis("Horizontal"), transform.localPosition.y + yDelta*Input.GetAxis("Jump"), transform.localPosition.z + zDelta * Input.GetAxis("Vertical"));

        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x + mousexDelta * Input.GetAxis("Mouse Y"), transform.localRotation.eulerAngles.y + mouseyDelta * Input.GetAxis("Mouse X"), transform.localRotation.eulerAngles.z);

    }
}
