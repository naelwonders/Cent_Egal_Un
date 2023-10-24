using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    
    public bool isDraggable = true;
    public bool isDragged = false;

    // Update is called once per frame
    void Update()
    {
        if (isDragged) {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition); //we cast to vector to loose the z axis otherwise the drag and drop does not work
        }
    }

    private void OnMouseOver()
    {
        if (isDraggable && Input.GetMouseButtonDown(0)) //int of the button pressed, here the left one
        {
            isDragged = true;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }
}
