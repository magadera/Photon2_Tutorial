using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject prefab;

    void Start()
    {
        prefab = Managers.Resource.Instantiate("Brick");
    }
}
