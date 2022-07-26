using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonFade : MonoBehaviour
{
    public Color color;
    public RawImage buttonColor;
    // Start is called before the first frame update
    private void Start()
    {

        color = buttonColor.color;
        
    }



    public void OnMouseOver()
    {
        Debug.Log("Over");
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
    }

    public void OnMouseExit()
    {
        Debug.Log("Exit");
    }
    private void Update()
    {
        //if (!isMouseOver())
        //{
        //    color.a = 0;
        //}
        //else
        //{
        //    color.a = 0.6f;
        //}
        buttonColor.color = color;

    }

    public bool isMouseOver()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
