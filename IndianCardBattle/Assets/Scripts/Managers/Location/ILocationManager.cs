using System.Collections.Generic;
using UnityEngine;

public interface ILocationManager
{
    void SetDependencies(IObjectSpawner objectSpawner, Transform transform);
    void SpawnLocations(List<LocationID> locationsToSpawn);
}