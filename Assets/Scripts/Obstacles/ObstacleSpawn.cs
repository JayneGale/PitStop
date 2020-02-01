using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public TextAsset obstaclesFile;
    public ObstacleType[] obstacleTypes;
    List<Obstacle> obstacles = new List<Obstacle>();

    public GameObject hole;
    public GameObject oilSlick;

    public Vector2[] holeSpawn;
    public Vector2[] oilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        ReadObstaclesFromFile();
        SpawnObjects();
        /*
        foreach (Vector2 holePos in holeSpawn)
        {
            SpawnObject(hole, holePos);
        }
        foreach (Vector2 oilPos in oilSpawn)
        {
            SpawnObject(oilSlick, oilPos);
        }*/
    }

    void ReadObstaclesFromFile()
    {
        string[] lines = obstaclesFile.text.Split('\n');
        foreach(string rawLine in lines)
        {
            string[] line = rawLine.Split(',');
            string name = line[0].Trim();
            string strX = line[1].Trim();
            string strY = line[2].Trim();

            int x;
            int y;

            if (!int.TryParse(strX ,out x))
            {
                Debug.Log("Could not pass x: " + strX);
            }
            else if (!int.TryParse(strY, out y))
            {
                Debug.Log("Could not pass x: " + strY);
            }
            else
            {
                obstacles.Add(new Obstacle(name, new Vector2(x, y)));
            }
        }
    }

    GameObject FindObstacle(string name)
    {
        GameObject gO = null;
        foreach(ObstacleType obstacleType in obstacleTypes)
        {
            if (name.ToLower() == obstacleType.name.ToLower())
            {
                gO = obstacleType.gameObject;
            }
        }
        if (!gO)
        {
            Debug.Log("Obstacle " + name + " not found");
        }
        return gO;
    }


    void SpawnObjects()
    {
        foreach (Obstacle obstacle in obstacles)
        {
            SpawnObject(FindObstacle(obstacle.name), obstacle.position);
        }
    }

    void SpawnObject(GameObject gO, Vector2 tilePosition)
    {
        Vector3 position = new Vector3(tilePosition.x, 0.1f, tilePosition.y);
        Instantiate(gO, position, Quaternion.identity);
    }
}

[System.Serializable]
public struct ObstacleType
{
    public string name;
    public GameObject gameObject;
}

public class Obstacle
{
    public string name;
    public Vector2 position;
    public Obstacle(string name, Vector2 position)
    {
        this.name = name;
        this.position = position;
    }
}
