﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise  {

    public static float Get2DPerlin(Vector2 position, float offset, float scale) {
        // need to add a bit in order of Unity to not generate the same seed (0.1f)
        return Mathf.PerlinNoise(((position.x + 0.1f) / VoxelData.ChunkWidth * scale) + offset,
            ((position.y + 0.1f) / VoxelData.ChunkWidth * scale) + offset);
    }

    public static bool Get3DPerlin(Vector3 position, float offset, float scale, float threshold)
    {
        // https://www.youtube.com/watch?v=Aga0TBJkchM Carpilot on YouTube

        float x = (position.x + offset + 0.1f) * scale;
        float y = (position.y + offset + 0.1f) * scale;
        float z = (position.z + offset + 0.1f) * scale;

        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);

        float BA = Mathf.PerlinNoise(y, x);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        // get the average of all the noise values.
        float f3dPerlinNoise = (AB + BC + AC + BA + CB + CA) / 6f;

        if (f3dPerlinNoise > threshold)
        {
            return true;
        }
        else
            return false;
    }
}
