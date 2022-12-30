using UnityEngine;

public interface IObjectSpawner
{
    T SpawnObjectOfType<T>(T prefabToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, Transform parentTransform)
        where T : MonoBehaviour;
}