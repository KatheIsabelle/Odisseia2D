using UnityEngine;

// This script can be used to match the positional values of a
// target transform. It's meant to be attached to the main camera
// so that the camera follows the player (or whatever the target is).
public class FollowTarget : MonoBehaviour
{
    [Header("Transform to Follow")]
    [SerializeField] private Transform targetTransform;  // Ensure this is assigned in the editor

    [Header("Configuration")]
    [SerializeField] private bool followX = true;
    [SerializeField] private bool followY = true;
    [SerializeField] private Vector2 offset = Vector2.zero;

    private void LateUpdate() 
    {
        // If we don't have a target transform, don't update
        if (targetTransform == null) 
        {
            Debug.LogWarning("Target Transform is not assigned.");
            return;
        }

        float newPosX = this.transform.position.x;
        float newPosY = this.transform.position.y;

        // Update position based on the target's position and the offset
        if (followX) 
        {
            newPosX = targetTransform.position.x + offset.x;
        }
        if (followY) 
        {
            newPosY = targetTransform.position.y + offset.y;
        }
        
        this.transform.position = new Vector3(newPosX, newPosY, this.transform.position.z);
    }
}
