using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScrollbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float amount;
    private bool pressed;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        pressed = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        pressed = false;
    }

    void FixedUpdate()
    {
        if (pressed && (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)))
        {
            float maxHeight = transform.GetChild(0).transform.position.y;
            float minHeight = transform.GetChild(1).transform.position.y;
            if (Input.mousePosition.y < maxHeight && Input.mousePosition.y > minHeight)
            {
                amount = -1 * (minHeight - Input.mousePosition.y) / (maxHeight - minHeight);
                gameObject.transform.parent.GetComponent<UpdatedGUIToText>().SetVar(gameObject.name, amount);
            }

        }
    }
}

