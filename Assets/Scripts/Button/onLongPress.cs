using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class onLongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onLongClick;
    public UnityEvent onNotClick;
    private bool isPressing;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
      
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
        isPressing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressing)
        {
            onLongClick.Invoke();
        } else
        {
            onNotClick.Invoke();
        }
    }
}
