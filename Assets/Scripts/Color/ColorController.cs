using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    //GameObject cube;
    Color myColor;
    public Renderer cubeRenderer;
    //TextMeshProUGUI myColorText = null;

    private void Awake()
    {
        cubeRenderer = this.GetComponent<Renderer>();
    }

    void Start()
    {
        //cube = GameObject.FindGameObjectWithTag("Cube");
        //if (cube != null)
        //    Debug.Log($"GameObject '{cube.name}'을 찾았습니다.");
        //else
        //    Debug.Log("해당하는 게임 오브젝트 찾지못함.");

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;

        //myColorText = TextManager.instance.textMeshProUGUI;
        //Debug.Log(myColorText.text);
        //myColorText.text = myColor.ToString();
    }

    void OnKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            cubeRenderer.material.color = myColor;
            Debug.Log("도색 완료");
        }

        if (Input.GetKeyDown("r"))
        {
            myColor = Color.red;
            Debug.Log("red 색 저장");
        }
        if (Input.GetKeyDown("g"))
        {
            myColor = Color.green;
            Debug.Log("green 색 저장");
        }
        if (Input.GetKeyDown("b"))
        {
            myColor = Color.blue;
            Debug.Log("blue 색 저장");
        }

        if (Input.GetKeyDown("m"))
        {
            myColor = Color.magenta;
            Debug.Log("magenta 색 저장");
        }
        if (Input.GetKeyDown("y"))
        {
            myColor = Color.yellow;
            Debug.Log("yellow 색 저장");
        }
        if (Input.GetKeyDown("c"))
        {
            myColor= Color.cyan;
            Debug.Log("cyan 색 저장");
        }

        if (Input.GetKeyDown("w"))
        {
            myColor = Color.white;
            Debug.Log("white 색 저장");
        }
        if (Input.GetKeyDown("k"))
        {
            myColor = Color.black;
            Debug.Log("balck 색 저장");
        }
        if (Input.GetKeyDown("e"))
        {
            myColor = Color.gray;
            Debug.Log("gray 색 저장");
        }

    }
}
