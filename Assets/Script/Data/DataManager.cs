using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static int MAP_SIZE = 100;

    public static DataManager instance;

    public List<Object> BlockList;

    public Dictionary<int, Object> MapBlockData;
    
    string dataPath = "Data/";
    string iconPath = "Icon/";
    string prefabPath = "Prefabs/";

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


        setData();

        setMap();
    }
    void setData()
    {
        setBlockData();
    }

    void setMap()
    {
        MapBlockData = new Dictionary<int, Object>();
    }

    void setBlockData()
    {
        BlockList = new List<Object>();

        List<Dictionary<string, string>> data = CSVReader.Read(dataPath + "block_data");

        foreach(Dictionary<string, string> d in data)
        {
            Object block = new Object();

            block.index = int.Parse(d["index"]);
            block.id = d["ID"];
            block.icon = Resources.Load<Sprite>(iconPath + "Block/i_" + block.id);
            if (block.icon == null)
                Debug.Log(block.id + " icon load fail!!");
            block.prefab = Resources.Load<GameObject>(prefabPath + "Block/p_" + block.id);
            if (block.prefab == null)
                Debug.Log(block.id + " prefab load fail!!");

            BlockList.Add(block);
        }

        BlockList.Sort(compareByIndex);
    }

    int compareByIndex(Object a, Object b)
    {
        return a.index - b.index;
    }
}
