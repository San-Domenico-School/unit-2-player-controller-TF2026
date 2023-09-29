using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    public Transform player;       // Reference to the player's GameObject.
    public Transform startPoint;   // The starting point of the road.
    public Transform endPoint;     // The ending point of the road.

    private void Update()
    {
        // Check if the player has reached the end of the road.
        if (player.position.z >= endPoint.position.z)
        {
            // Calculate the distance the player has traveled beyond the endpoint.
            float distanceBeyondEnd = player.position.z - endPoint.position.z;

            // Teleport the player back to the starting point with an offset.
            player.position = startPoint.position + new Vector3(0f, 0f, distanceBeyondEnd);
        }
    }
}
