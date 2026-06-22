using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, speed;

    public Tower.Shape myShape;

    public GameObject[] goal;

    public AudioSource lastBreath;

    // Find target object to move towards before the first frame occurs
    void Awake()
    {
        goal = GameObject.FindGameObjectsWithTag("End");
    }

    // Destroy itself once health is zero or below and simply move straight towards the target
    void Update()
    {
        if (health <= 0)
        {
            if (myShape == Tower.Shape.circle)
            {
                GameManager.game.score += 10;
            }

            if (myShape == Tower.Shape.triangle)
            {
                GameManager.game.score += 20;
            }

            if (myShape == Tower.Shape.hexagon)
            {
                GameManager.game.score += 30;
            }

            lastBreath.Play();
            Destroy(gameObject);
        }
    }
}
