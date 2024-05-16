using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathmakerScript : MonoBehaviour
{

    public GameObject tile;

    int[,] terrain =
    {
        {2, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
        {0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0 },
        {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 3 }
    };



    // Start is called before the first frame update
    void Start()
    {

        float width = tile.GetComponent<Renderer>().bounds.extents.x * 2;

        for(int i = 0; i < terrain.GetLength(0); i++)
        {
            for(int j = 0; j < terrain.GetLength(1); j++)
            {
                GameObject obj = Instantiate(tile);
                obj.transform.position = new Vector3(width * i, 0, width * j);
                if (terrain[i, j] == 0)
                {
                    obj.GetComponent<Renderer>().material.color = Color.green;
                }
                if (terrain[i, j] == 1)
                {
                    obj.GetComponent<Renderer>().material.color = Color.white;
                }
                if (terrain[i, j] == 2)
                {
                    obj.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (terrain[i, j] == 3)
                {
                    obj.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }

        CalculatePath();

    }

    List<Vector2> CalculatePath()
    {
        List<Vector2> path = new List<Vector2>();
        for(int i = 0; i <terrain.GetLength(0); i++)
        {
            for(int j = 0; j < terrain.GetLength(1); j++)
            {
                if (terrain[i, j] != 0)
                {
                    path.Add(new Vector2(i, j));
                }
            }
        }

        return path;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
