using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float smoothSpeed = 0.125f; // Adjust the smoothness of the camera movement

    private Vector3 offset; // Store the initial offset between the camera and player

    void Start()
    {
        // Calculate the initial offset
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Calculate the new camera position
        Vector3 targetPosition = player.position + offset;

        // Only move the camera on the X-axis
        targetPosition.y = transform.position.y;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }





    /* [SerializeField] private float speed;
     private float currentPoxX;
     private Vector3 velocity = Vector3.zero;

     private void Update()
     {
         transform.position = Vector3.SmoothDamp(transform.position,
             new Vector3(currentPoxX,transform.position.y,transform.position.z),ref velocity, speed * Time.deltaTime);
     }
     public void MoveNewRoom(Transform newroom)
     {
         currentPoxX = newroom.position.x;
     }*/
}
