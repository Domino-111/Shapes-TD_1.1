using UnityEngine;

public class Base : MonoBehaviour
{
    public GameManager gm;
    public LevelManager lm;

    void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
        lm = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gm.scorePage.SetActive(true);
            gm.isPlaying = false;
            gm.gameEnded = true;

            for (int i = 0; i < lm.levels.Count; i++)
            {
                lm.levels[i].SetActive(false);
            }

            Debug.Log("Collision detected");
        }
    }
}
