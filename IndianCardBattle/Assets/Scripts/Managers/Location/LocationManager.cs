using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : ILocationManager
{
   private List<Location> locations;
   private Transform selfTransform;
   private IObjectSpawner objectSpawner;
   private TurnManager turnManager;

   public LocationManager(TurnManager turnManager,IObjectSpawner objectSpawner, Transform transform)
   {
      this.turnManager = turnManager;
      this.objectSpawner = objectSpawner;
      selfTransform = transform;
      locations = new List<Location>();
      
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
         toSpawn = objectSpawner.SpawnObjectOfType(toSpawn, spawnPos, Quaternion.identity, selfTransform);
         toSpawn.InitLocation(turnManager,locationID,i+1,Constants.NUMBER_OF_PLAYERS);
         locations.Add(toSpawn);
      }
   }

   private List<LocationID> GetRandomListOfLocations()
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

   public void AddCardToLocation(int playerIndex, Location location, ICard card)
   {
      location.AddCardToLocation(playerIndex, card);
   }
}
