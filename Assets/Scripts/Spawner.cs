using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyCircle, enemyTriangle, enemyHexagon;

    public float timer, resetTime, spawnRate;

    public int waveCounter = 0, maxWaves, triangleWave, hexagonWave;

    public bool endless = false;

    void Update()
    {
        timer -= Time.deltaTime;

        // Timer for levels
        if (timer <= 0f && waveCounter != maxWaves && endless == false)
        {
            StartCoroutine("Spawn");

            waveCounter++;

            timer = resetTime;
        }

        // Timer for endless mode
        if (timer <= 0f && endless == true)
        {
            StartCoroutine("Spawn");

            waveCounter++;

            timer = resetTime;
        }
    }

    public IEnumerator Spawn()
    {
        // Spawn a circle enemy and stagger their spawn so it's visible there's multiple
        for (int i = 0; i < waveCounter; i++)
        {
            Instantiate(enemyCircle, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(spawnRate);
        }

        // Spawn a triangle enemy once specified wave is reached and stagger their spawn so it's visible there's multiple
        if (waveCounter >= triangleWave)
        {
            for (int i = 0; i < waveCounter - triangleWave + 1; i++)
            {
                Instantiate(enemyTriangle, transform.position, Quaternion.identity, transform);

                yield return new WaitForSeconds(spawnRate);
            }
        }

        // Spawn a hexagon enemy once specified wave is reached and stagger their spawn so it's visible there's multiple
        if (waveCounter >= hexagonWave)
        {
            for (int i = 0; i < waveCounter - hexagonWave + 1; i++)
            {
                Instantiate(enemyHexagon, transform.position, Quaternion.identity, transform);

                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
