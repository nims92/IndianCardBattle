using UnityEngine;

public class MouseInteractionHandler : InteractionHandler
{
    private bool touchDown = false;

    public override void InputUpdate()
    {
        //TODO: add check for input disabled
        /*if (GameManager.Instance.InputDisabled || GameManager.Instance.GameIsOver)
            return;*/

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