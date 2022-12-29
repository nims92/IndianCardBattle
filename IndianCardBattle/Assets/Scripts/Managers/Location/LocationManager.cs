using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
   private List<Location> locations;
   private Transform selfTransform;

   private void Awake()
   {
      selfTransform = transform;
      locations = new List<Location>();
   }

   private void Start()
   {
      //TODO: remove this code
      SpawnLocations(new List<LocationID>(){LocationID.Dwarka, LocationID.Gandhar, LocationID.Hastinapur});
   }

   public void SpawnLocations(List<LocationID> locationsToSpawn)
   {
      Location toSpawn;
      Vector3 spawnPos;
      
      for(int i=0; i<locationsToSpawn.Count; i++)
      {
         spawnPos = GameData.Instance.GetLocationSpawnPosForIndex(i);
         toSpawn = GameData.Instance.GetLocationPrefabWithID(locationsToSpawn[i]);
         toSpawn = Instantiate(toSpawn.gameObject,spawnPos,Quaternion.identity,selfTransform).GetComponent<Location>();
         locations.Add(toSpawn);
      }
   }
}
