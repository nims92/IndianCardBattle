using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LocationManager : MonoBehaviour,ILocationManager
{
   private List<Location> locations;
   private Transform selfTransform;
   private IObjectSpawner objectSpawner;

   private int locationsWonByPlayer;
   private int locationsWonByOpponent;
   
   public static LocationManager Instance { get; private set; }

   public int LocationsWonByPlayer
   {
      get => locationsWonByPlayer;
      set => locationsWonByPlayer = value;
   }

   public int LocationsWonByOpponent
   {
      get => locationsWonByOpponent;
      set => locationsWonByOpponent = value;
   }

   private void Awake() 
   { 
      // If there is an instance, and it's not me, delete myself.
    
      if (Instance != null && Instance != this) 
      { 
         Destroy(this); 
      } 
      else 
      { 
         Instance = this; 
      } 
   }

   public void SetDependencies(IObjectSpawner objectSpawner, Transform transform)
   {
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
         toSpawn.InitLocation(locationID,i+1,Constants.NUMBER_OF_PLAYERS);
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

   //TODO remove this code
   public ILocation GetRandomLocation()
   {
      return locations[Random.Range(0,locations.Count)];
   }

   public void CalculateDataForGameEndScreen()
   {
      foreach (var location in locations)
      {
         int playerScore = location.LocationScoreManager.GetScoreForPlayer(0);
         int opponentScore = location.LocationScoreManager.GetScoreForPlayer(1);
         
         if (playerScore > opponentScore)
         {
            LocationsWonByPlayer++;
         }
         else if (playerScore < opponentScore)
         {
            LocationsWonByOpponent++;
         }
      }
   }
}
