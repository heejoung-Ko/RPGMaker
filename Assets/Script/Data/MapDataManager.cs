using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataManager : MonoBehaviour
{
    public static MapDataManager instance;

    static int MAP_SIZE = 100;
    static int MAP_HALF_SIZE;

    static int EMPTY = -1;

    public Dictionary<int, int> MapBlockData;

    string dataPath = "Data/";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }

        MAP_HALF_SIZE = MAP_SIZE / 2;

        init();
    }

    void init()
    {
        MapBlockData = new Dictionary<int, int>();

        for (int i = 0; i < MAP_SIZE; i++)
            for (int j = 0; j < MAP_SIZE; j++)
                for (int k = 0; k < MAP_SIZE; k++)
                {
                    int index = i * MAP_SIZE * MAP_SIZE + j * MAP_SIZE + k;
                    MapBlockData.Add(index, EMPTY);
                }
    }

    public bool SetBlock(Vector3 pos, Object block)
    {
        int x = (int)pos.x + MAP_HALF_SIZE;
        int y = (int)pos.y + MAP_HALF_SIZE;
        int z = (int)pos.z + MAP_HALF_SIZE;

        int index = x * MAP_SIZE * MAP_SIZE + y * MAP_SIZE + z;

        if (MapBlockData[index] != EMPTY)
        {
            Debug.Log("This Postion Already Set Block");
            return false;
        }

        MapBlockData[index] = block.index;

        return true;
    }
    public bool RemoveBlock(Vector3 pos)
    {
        int x = (int)pos.x + MAP_HALF_SIZE;
        int y = (int)pos.y + MAP_HALF_SIZE;
        int z = (int)pos.z + MAP_HALF_SIZE;

        int index = x * MAP_SIZE * MAP_SIZE + y * MAP_SIZE + z;

        if (MapBlockData[index] == EMPTY)
        {
            Debug.Log("This Postion Already Empty");
            return false;
        }

        MapBlockData[index] = EMPTY;

        return true;
    }

    public void SaveMapData()
    {
        var writer = new CsvFileWriter(dataPath + "map_data.csv");


    }

    public void LoadMapData()
    {
        init();

    }
}
