using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    public static ModeController instance;

    public enum MODE
    {
        DEFAULT,
        SET_BLOCK,
        REMOVE_BLOCK,
        SAVE_AND_LOAD
    }

    [SerializeField]
    GameObject setBlockMode;    // 블록 설치 모드

    [SerializeField]
    GameObject removeBlockMode; // 블록 제거 모드

    [SerializeField]
    GameObject SaveAndLoadMode; // 저장 불러오기 모드

    GameObject presentMode = null;      // 현재 모드

    static float MIN_LENGHT = 0;
    static float MAX_LENGHT = 100;

    [Space(10)]

    [SerializeField]
    float lenght = 0;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            //DontDestroyOnLoad(gameObject);  
        } 
        else 
        { 
            if (instance != this)
                Destroy(this.gameObject); 
        }

        setBlockMode.SetActive(false);
        removeBlockMode.SetActive(false);

        ChangeMode(MODE.DEFAULT);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ChangeMode(MODE.DEFAULT);
        else if (Input.GetKeyDown(KeyCode.F2))
            ChangeMode(MODE.SET_BLOCK);
        else if (Input.GetKeyDown(KeyCode.F3))
            ChangeMode(MODE.REMOVE_BLOCK);
        else if (Input.GetKeyDown(KeyCode.F4))
            ChangeMode(MODE.SAVE_AND_LOAD);
    }

    public float GetLenght()
    {
        return lenght;
    }

    public float GetNomalizedLength()
    {
        return lenght / (MAX_LENGHT - MIN_LENGHT);
    }

    public void ChangeLength(float nomalize)
    {
        lenght = (MAX_LENGHT - MIN_LENGHT) * nomalize;
    }

    public void ChangeMode(MODE mode)
    {
        if (presentMode != null)
        {
            presentMode.SetActive(false);
        }

        switch(mode)
        {
            case MODE.DEFAULT:
                presentMode = null;
                break;

            case MODE.SET_BLOCK:
                presentMode = setBlockMode;
                break;

            case MODE.REMOVE_BLOCK:
                presentMode = removeBlockMode;
                break;

            case MODE.SAVE_AND_LOAD:
                presentMode = SaveAndLoadMode;
                break;
        }

        if (presentMode != null)
        {
            presentMode.SetActive(true);
        }
    }

    public void ChangeSelectSlot(Object obj)
    {
        setBlockMode.GetComponent<SetBlockMode>().ChangeSelectBlock(obj);
    }
}
