using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData {

    public static readonly int ChunkWidth = 16;
    public static readonly int ChunkHeight = 128;
    public static readonly int WorldSizeInChunks = 15;

    public static int WorldSizeInVoxels {
        get { return WorldSizeInChunks * ChunkWidth; }
    }

    public static readonly int ViewDistanceInChunks = 5;

    // number of blocks in row/column on texture atlas
    public static readonly int TextureAtlasSizeToBlocks = 16;
    public static float NormalizedBlockTextureSize { get { return (1.0f / (float)TextureAtlasSizeToBlocks); } }

    /// <summary>
    /// List of voxel coords "offset"
    /// </summary>
    public static readonly Vector3[] voxelVerts = new Vector3[8] {
        new Vector3(0.0f, 0.0f, 0.0f), // 0
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f), // 7
    };

    public static readonly Vector3[] faceChecks = new Vector3[6] {
        new Vector3( 0.0f,  0.0f, -1.0f), // Back Face
        new Vector3( 0.0f,  0.0f,  1.0f), // Front Face
        new Vector3( 0.0f,  1.0f,  0.0f), // Top Face
        new Vector3( 0.0f, -1.0f,  0.0f), // Bottom Face
        new Vector3(-1.0f,  0.0f,  0.0f), // Left Face
        new Vector3( 1.0f,  0.0f,  0.0f), // Right Face
    };

    /// <summary>
    /// Triangles must be configured in a clockwise order, otherwise it will not render facing correct side.
    /// contains index of voxelVerts that make up triangle
    /// </summary>
    public static readonly int[,] voxelTris = new int[6, 4] {
        {0, 3, 1, 2 }, // Back Face
        {5, 6, 4, 7 }, // Front Face        
        {3, 7, 2, 6 }, // Top Face
        {1, 5, 0, 4 }, // Bottom Face
        {4, 7, 0, 3 }, // Left Face
        {1, 2, 5, 6 }  // Right Face
    };


    /// <summary>
    /// Look up table for texture UVs local positions
    /// </summary>
    public static readonly Vector2[] voxelUVs = new Vector2[4] {
        new Vector2(0.0f, 0.0f), // Text BL
        new Vector2(0.0f, 1.0f), // Text TL
        new Vector2(1.0f, 0.0f), // Text BR
        new Vector2(1.0f, 1.0f)  // Text BR
    };
}
