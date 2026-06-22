using UnityEngine;

public class Base : MonoBehaviour
{
    public GameManager gm;

    void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.scorePage.SetActive(true);
        gm.gamePage.SetActive(false);
        gm.isPlaying = false;
        gm.gameEnded = true;

        Debug.Log("Collision detected");
    }
}
