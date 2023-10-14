using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 16;
    public int height = 8;
    public int minPathLenth = 20;
    public int objectChance = 30;
    public int enemyCount = 10;

    public GameObject dirtPrefab;
    public GameObject grassPrefab;
    public GameObject treePrefab;
    public GameObject rockPrefab;
    public GameObject rock2Prefab;
    public GameObject forestPrefab;
    public GameObject forest2Prefab;
    public List<Vector2Int> pathCells;



    private PathGenerater pathGenerater;
    // Start is called before the first frame update
    void Awake()
    {
        pathGenerater = new PathGenerater(width, height);


        
        pathCells = pathGenerater.GeneratePath();
        int pathCellsCount = pathCells.Count;
        while (pathCellsCount < minPathLenth)
        {
            pathCells = pathGenerater.GeneratePath();
            pathCellsCount = pathCells.Count;
        }


        layPathCells(pathCells);
        layGrassCells();
        
    }

    private void layPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int cell in pathCells)
        {
            Instantiate(dirtPrefab, new Vector3(cell.x, 0f, cell.y), Quaternion.identity);

        }

    }

    private void layGrassCells()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y <height; y++)
            {
                if (pathGenerater.CellisFree(x, y))
                {
                    int random = Random.Range(0, 100);
                    if (random < objectChance)
                    {
                        int randomObject = Random.Range(0, 150);
                        if (randomObject < 30)
                        {
                            Instantiate(treePrefab, new Vector3(x, 0f, y), Quaternion.identity);
                        }
                        else if (randomObject < 60)
                        {
                            Instantiate(forestPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                        }
                        else if (randomObject < 90)
                        {
                            Instantiate(forest2Prefab, new Vector3(x, 0f, y), Quaternion.identity);
                        }
                        else if (randomObject < 120)
                        {
                            Instantiate(rockPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(rock2Prefab, new Vector3(x, 0f, y), Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(grassPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    }

                }
            }
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
