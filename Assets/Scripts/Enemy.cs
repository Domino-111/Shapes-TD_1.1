using MyPathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, speed;

    public Tower.Shape myShape;

    public AudioSource lastBreath;

    public Dijkstra pathFinder;

    public MyPathfinding.Node goalNode;
    public MyPathfinding.Node startNode;

    public List<MyPathfinding.Node> path = new List<MyPathfinding.Node>();

    private int point = 0;

    private GameManager gm;

    private int towerCheck;

    private Vector2 currentPosition;

    // Find target object to move towards before the first frame occurs
    void Awake()
    {
        pathFinder = Dijkstra.FindFirstObjectByType<Dijkstra>();
        gm = GameManager.FindFirstObjectByType<GameManager>();

        pathFinder.GetAllNodes();

        MyPathfinding.Node[] nodes = FindObjectsByType<MyPathfinding.Node>(FindObjectsSortMode.InstanceID);

        for (int i = 0; i < nodes.Length; i ++)
        {
            if (nodes[i].CompareTag("Start"))
            {
                startNode = nodes[i];
            }
        }

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].CompareTag("Goal"))
            {
                goalNode = nodes[i];
            }
        }
    }

    void Start()
    {
        CalculatePath();
    }

    void Update()
    {
        MoveToNextPoint();

        // Destroy itself once health is zero or below
        if (health <= 0)
        {
            // Depending on tower shape a different amount of points will be added
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

    public void MoveToNextPoint()
    {
        // Move towards the next point
        transform.position = Vector3.MoveTowards(transform.position, path[point].transform.position, speed * Time.deltaTime);

        // Once poisiton is same or near the target node switch target to the next node in the list
        if (Vector3.Distance(transform.position, path[point].transform.position) <= 0.00001f)
        {
            point += 1;

            startNode = path[point];
        }
    }

    // Calculates the shortest path the final node determined in game
    private void CalculatePath()
    {
        path = pathFinder.FindShortestPath(startNode, goalNode);
        point = 0;
    }
}
