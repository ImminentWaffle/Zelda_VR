﻿using UnityEngine;
using System.Collections.Generic;

public class GrottoSpawnPoint : MonoBehaviour
{
    public GameObject grottoPrefab;
    public GameObject marker;           // Marks the Grotto's ground-level entrance location

    public Grotto.GrottoType grottoType;
    public string text;
    public int giftAmount;

    public GameObject npcSpawnPointPrefab;

    public Collectible uniqueCollectiblePrefab;
    public Collectible giftPrefab;

    public bool showEntranceWalls;                  // Entrance Walls are the part of the Grotto that exists above ground level
    public bool HasSpecialResourceBeenTapped        // (i.e. HeartContainer or Potion collected, Gift collected, UniqueCollectible collected)
    {
        get { return _overworldInfo.HasGrottoBeenTapped(this); }
        set { _overworldInfo.SetGrottoHasBeenTapped(this, value); }
    }


    public Collectible saleItemPrefabA, saleItemPrefabB, saleItemPrefabC;
    public List<Collectible> SaleItemPrefabs {
        get {
            return new List<Collectible>() {
                saleItemPrefabA,
                saleItemPrefabB,
                saleItemPrefabC
            };
        }
    } 
    public int saleItemPriceA, saleItemPriceB, saleItemPriceC;
    public List<int> SaleItemPrices
    {
        get
        {
            return new List<int>() {
                saleItemPriceA,
                saleItemPriceB,
                saleItemPriceC
            };
        }
    }

    public string[] payForInfoText;

    public GrottoSpawnPoint warpToA, warpToB, warpToC;
    public int warpDestination_Left, warpDestination_Mid, warpDestination_Right;
    public int GetWarpDestinationIndexForPortal(GrottoPortal portal)
    {
        if(portal == null)
        {
            return -1;
        }

        int idx = -1;
        switch (portal.Location)
        {
            case GrottoPortal.LocationType.Left:    idx = warpDestination_Left; break;
            case GrottoPortal.LocationType.Mid:     idx = warpDestination_Mid; break;
            case GrottoPortal.LocationType.Right:   idx = warpDestination_Right; break;
            default: break;
        }
        return idx;
    }


    OverworldInfo _overworldInfo;
    Transform _grottosContainer;


    public Grotto SpawnedGrotto { get; private set; }


    void Awake()
    {
        // TODO: Don't use GameObject.Find

        _grottosContainer = GameObject.Find("Grottos").transform;
        GameObject go = GameObject.Find(ZeldaTags.OVERWORLD_INFO);
        _overworldInfo = GameObject.FindGameObjectWithTag(ZeldaTags.OVERWORLD_INFO).GetComponent<OverworldInfo>();

        marker.SetActive(false);
    }


    public Grotto SpawnGrotto()
    {
        if(SpawnedGrotto != null)
        {
            //Debug.LogWarning("SpawnedGrotto already exists.  It will be Destroyed and replaced with a new instance.");
            DestroyGrotto();
        }
        SpawnedGrotto = InstantiateGrotto();
        return SpawnedGrotto;
    }

    Grotto InstantiateGrotto()
    {
        GameObject g = Instantiate(grottoPrefab, transform.position, transform.rotation) as GameObject;
        g.name = "Grotto - " + grottoType.ToString();
        g.transform.SetParent(_grottosContainer);

        Grotto gr = g.GetComponent<Grotto>();
        gr.GrottoSpawnPoint = this;
        gr.Type = grottoType;

        return gr;
    }


    public void DestroyGrotto()
    {
        if (SpawnedGrotto == null) { return; }
        
        Destroy(SpawnedGrotto.gameObject);
        SpawnedGrotto = null;
    }


    #region Serialization

    public class Serializable
    {
        public bool hasSpecialResourceBeenTapped;
    }

    public Serializable GetSerializable()
    {
        Serializable info = new Serializable();

        info.hasSpecialResourceBeenTapped = HasSpecialResourceBeenTapped;

        return info;
    }

    public void InitWithSerializable(Serializable info)
    {
        HasSpecialResourceBeenTapped = info.hasSpecialResourceBeenTapped;
    }

    #endregion Serialization
}