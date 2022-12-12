using UnityEngine;

public class TouchInteractionHandler: InteractionHandler
{
    private Touch currentTouch;

    public override void InitialSetup()
    {
        Input.multiTouchEnabled = false;
    }

    public override void InputUpdate()
    {
        //TODO: add check for input disabled

        //For Mobile Devices
        if (Input.touchCount == 1)
        {
            currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                OnTouchDown(currentTouch.position);
            }
            else if (currentTouch.phase == TouchPhase.Moved
                || currentTouch.phase == TouchPhase.Stationary)
            {
                OnTouchMove(currentTouch.position);
            }
            else if (currentTouch.phase == TouchPhase.Ended)
            {
                OnTouchUp();
            }
        }
    }
}