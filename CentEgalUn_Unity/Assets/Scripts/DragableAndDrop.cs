using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("pointer START");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("pointer DRAG");
        //transform.position = Input.mouse;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("pointer END");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
