using UnityEngine;

public class MouseInteractionHandler : InteractionHandler
{
    private bool touchDown = false;
    
    protected override void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchDown = true;
            OnTouchDown(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            touchDown = false;
            OnTouchUp();
        }
        else if(touchDown)
        {
            OnTouchMove(Input.mousePosition);
        }
    }
}