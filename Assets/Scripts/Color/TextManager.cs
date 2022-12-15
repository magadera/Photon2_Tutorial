using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        instance = this;
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
    }

    public static TextManager Instance
    {
        get { return instance; }
    }
}
