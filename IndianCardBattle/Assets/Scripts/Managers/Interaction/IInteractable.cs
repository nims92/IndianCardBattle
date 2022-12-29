using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public interface IInteractable
{
    public bool IsInteractable { get; set; }

    public void OnTouchDown(Vector3 position);
    public void OnTouchMove(Vector3 position);
    public void OnTouchUp();
}