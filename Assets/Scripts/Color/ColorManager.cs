using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    GameObject cube;
    Color myColor;
    public Renderer cubeRenderer;
    TextMeshProUGUI myColorText = null;

    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");
        if (cube != null)
            Debug.Log($"GameObject '{cube.name}'�� ã�ҽ��ϴ�.");
        else
            Debug.Log("�ش��ϴ� ���� ������Ʈ ã������.");
        cubeRenderer = cube.GetComponent<Renderer>();

        //myColorText = TextManager.instance.textMeshProUGUI;
        //Debug.Log(myColorText.text);
    }

    void Update()
    {
        //cubeRender.material.SetColor("_Color", Color.green);
        myColor = SetColor();
        Debug.Log(myColor);
    }

    private void LateUpdate()
    {
        //myColorText.text = myColor.ToString();
        //Debug.Log(myColor.ToString());
        ChangeColor(cubeRenderer);
    }

    void ChangeColor(Renderer cr)
    {
        if (Input.GetKeyDown(KeyCode.Return))
            cr.material.color = myColor;
    }

    Color SetColor()
    {
        if (Input.GetKeyDown("r"))
            return Color.red;
        if (Input.GetKeyDown("g"))
            return Color.green;
        if (Input.GetKeyDown("b"))
            return Color.blue;

        if (Input.GetKeyDown("m"))
            return Color.magenta;
        if (Input.GetKeyDown("y"))
            return Color.yellow;
        if (Input.GetKeyDown("c"))
            return Color.cyan;

        if (Input.GetKeyDown("w"))
            return Color.white;
        if (Input.GetKeyDown("k"))
            return Color.black;
        if (Input.GetKeyDown("e"))
            return Color.gray;

        else
        {
            return Color.clear;    // ����
        }
    }
}
