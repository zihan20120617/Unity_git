using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Type type = typeof(T);

                instance = (T)FindObjectOfType(type);
                if (instance == null)
                {
                    Debug.LogError(type + " をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    virtual protected void Awake()
    {
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        if (dontDestroyOnLoad == true)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
