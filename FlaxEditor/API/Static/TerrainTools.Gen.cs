// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;
using FlaxEngine;
using Object = FlaxEngine.Object;

namespace FlaxEditor
{
    /// <summary>
    /// Terrain tools for editor. Allows to create and modify terrain.
    /// </summary>
    public static partial class TerrainTools
    {
        /// <summary>
        /// Performs a raycast against this terrain collision shape. Returns the hit chunk.
        /// </summary>
        /// <param name="terrain">The terrain.</param>
        /// <param name="ray">The ray.</param>
        /// <param name="resultHitDistance">The raycast result hit position distance from the ray origin. Valid only if raycast hits anything.</param>
        /// <param name="resultPatchCoord">The raycast result hit terrain patch coordinates (x and z). Valid only if raycast hits anything.</param>
        /// <param name="resultChunkCoord">The raycast result hit terrain chunk coordinates (relative to the patch, x and z). Valid only if raycast hits anything.</param>
        /// <param name="maxDistance">The maximum distance the ray should check for collisions.</param>
        /// <returns>True if ray hits an object, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool RayCastChunk(Terrain terrain, Ray ray, out float resultHitDistance, out Int2 resultPatchCoord, out Int2 resultChunkCoord, float maxDistance = float.MaxValue)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_RayCastChunk(Object.GetUnmanagedPtr(terrain), ref ray, out resultHitDistance, out resultPatchCoord, out resultChunkCoord, maxDistance);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_RayCastChunk(IntPtr terrain, ref Ray ray, out float resultHitDistance, out Int2 resultPatchCoord, out Int2 resultChunkCoord, float maxDistance);
#endif

        #endregion
    }
}
