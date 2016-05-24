﻿using UnityEngine;
using Uniblocks;
using System.Collections.Generic;

public class OverworldTerrainEngine : Engine
{
    public static OverworldTerrainEngine Instance { get { return EngineInstance as OverworldTerrainEngine; } }


    public TileMap TileMap { get { return FindObjectOfType<TileMap>(); } }
    public OverworldChunkLoader ChunkLoader { get { return FindObjectOfType<OverworldChunkLoader>(); } }

    public GameObject GroundPlane { get { return GameObject.FindGameObjectWithTag("GroundPlane"); } }
    public bool GroundPlaneCollisionEnabled
    {
        get { return (GroundPlane == null) ? false : GroundPlane.GetComponent<Collider>().enabled; }
        set
        {
            if (GroundPlane == null) { return; }
            GroundPlane.GetComponent<Collider>().enabled = value;
        }
    }
    public bool GroundPlaneRenderingEnabled
    {
        get { return (GroundPlane == null) ? false : GroundPlane.GetComponent<Renderer>().enabled; }
        set
        {
            if (GroundPlane == null) { return; }
            GroundPlane.GetComponent<Renderer>().enabled = value;
        }
    }


    void Start()
    {
        RefreshActiveStatus();
    }
    void OnLevelWasLoaded(int level)
    {
        RefreshActiveStatus();
    }

    void RefreshActiveStatus()
    {
        bool doActivate = WorldInfo.Instance.IsOverworld;

        if (ChunkLoader != null)
        {
            ChunkLoader.enabled = doActivate;
            if (doActivate)
            {
                ChunkLoader.DoSpawnChunks();
            }
        }

        ChunkManagerInstance.enabled = doActivate;
    }


    public void ForceRegenerateTerrain(List<Chunk> chunks = null)
    {
        if(!WorldInfo.Instance.IsOverworld)
        {
            return;
        }

        OverworldChunkManager cm = ChunkManagerInstance as OverworldChunkManager;
        cm.ForceRegenerateTerrain(chunks);
    }
}