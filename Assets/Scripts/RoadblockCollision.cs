using UnityEngine;
using UnityEngine.UI;

public class RoadblockCollision : MonoBehaviour
{
    public GameObject gameOverScreen; // Reference to the game over screen GameObject.
    public Text gameOverText;         // Reference to the Text component displaying "Game Over."

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Roadblock"))
        {
            // Disable player movement (if applicable).
            // You may need to add more logic here depending on your player setup.

            // Show the game over screen.
            gameOverScreen.SetActive(true);

            // Display "Game Over" text.
            gameOverText.text = "Game Over";
        }
    }
}
