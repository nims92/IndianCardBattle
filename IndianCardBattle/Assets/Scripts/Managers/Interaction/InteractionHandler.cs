using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    #region MonoBehaviour
    private void Awake()
    {
        InitialSetup();
    }

    void Update()
    {
        InputUpdate();
    }

    #endregion

    public virtual void InitialSetup() { }

    public virtual void InputUpdate() { }

    public void OnTouchDown(Vector3 inputPosition)
    {
        //TODO: implementation pending
    }

    public void OnTouchMove(Vector3 inputPosition)
    {
        //TODO: implementation pending
    }

    public void OnTouchUp()
    {
        //TODO: implementation pending
    }
}
