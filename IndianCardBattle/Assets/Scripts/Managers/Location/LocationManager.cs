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
#if CHEAT_ENABLED
      SpawnLocations(GameData.Instance.CheatData.locationSpawnList);
#else
      SpawnLocations(GetRandomListOfLocations());
#endif
   }
   
   public void SpawnLocations(List<LocationID> locationsToSpawn)
   {
      if (locationsToSpawn.Count != Constants.NUMBER_OF_LOCATIONS)
      {
         Debug.LogAssertion("Incorrect number of locations.");
         return;
      }
      
      Location toSpawn;
      Vector3 spawnPos;
      LocationID locationID;
      
      for(int i=0; i<locationsToSpawn.Count; i++)
      {
         locationID = locationsToSpawn[i];
         spawnPos = GameData.Instance.GetLocationSpawnPosForIndex(i);
         toSpawn = GameData.Instance.GetLocationPrefabWithID(locationID);
         toSpawn = Instantiate(toSpawn.gameObject,spawnPos,Quaternion.identity,selfTransform).GetComponent<Location>();
         toSpawn.InitLocation(locationID,i+1,Constants.NUMBER_OF_PLAYERS);
         locations.Add(toSpawn);
      }
   }

   public List<LocationID> GetRandomListOfLocations()
   {
      List<LocationDataEntry> data = Utilities.GetRandomElements(GameData.Instance.LocationDatabase.locationList,
         Constants.NUMBER_OF_LOCATIONS);

      return new List<LocationID>()
      {
         data[0].locationID,
         data[1].locationID,
         data[2].locationID
      };
   }
}
