﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool dontDestroy = false;

    static T m_instance;

    public static T Instance
    {
        get
        {
            if (isInstanceNull())
            {
                m_instance = GameObject.FindObjectOfType<T>();
                if (isInstanceNull())
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    m_instance = singleton.AddComponent<T>();
                }
            }
            return m_instance;
        }
    }
    public virtual void Awake()
    {
        if (isInstanceNull())
        {
            m_instance = this as T;
            if (dontDestroy)
            {
                transform.parent = null;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static bool isInstanceNull()
    {
        return m_instance == null;
    }
}