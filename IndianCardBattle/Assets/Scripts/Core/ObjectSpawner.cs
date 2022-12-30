using UnityEngine;
public class ObjectSpawner: MonoBehaviour, IObjectSpawner
{
    public T SpawnObjectOfType<T>(T prefabToSpawn,Vector3 spawnPosition,Quaternion spawnRotation,Transform parentTransform)
        where T : MonoBehaviour
    {
        return Instantiate(prefabToSpawn.gameObject, spawnPosition, spawnRotation, parentTransform).GetComponent<T>();
    }
}