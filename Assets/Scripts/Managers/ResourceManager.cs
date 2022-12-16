using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        // Object의 Instantiate()이라고 명시해줘야 ResourceManager의 Instantiate() 재귀호출 하는걸 막을 수 있음
        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go, float t)
    {
        if (go == null)
        {
            return;
        }
        Object.Destroy(go, t);
    }
}
