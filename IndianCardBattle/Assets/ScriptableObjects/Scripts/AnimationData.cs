using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationDatabase", menuName = "Scriptable Objects/Animation Database", order = 1)]
public class AnimationData : ScriptableObject
{
    [Header("Animation Timings")] 
    public float cardSnapMovementTime;
    public float cardNormalMovementTime;
    public float cardScaleAnimationTime;
}