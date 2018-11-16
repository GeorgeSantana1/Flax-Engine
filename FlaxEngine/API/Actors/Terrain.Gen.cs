// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Represents a single terrain object.
    /// </summary>
    [Serializable]
    public sealed partial class Terrain : Actor
    {
        /// <summary>
        /// Creates new <see cref="Terrain"/> object.
        /// </summary>
        private Terrain() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="Terrain"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static Terrain New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(Terrain)) as Terrain;
#endif
        }

        /// <summary>
        /// Gets or sets the terrain Level Of Detail bias value. Allows to increase or decrease rendered terrain quality.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(50), Limit(-100, 100, 0.1f), EditorDisplay("Terrain", "LOD Bias"), Tooltip("Terrain Level Of Detail bias value. Allows to increase or decrease rendered terrain quality.")]
        public int LODBias
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLODBias(unmanagedPtr); }
            set { Internal_SetLODBias(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain forced Level Of Detail index. Allows to bind the given terrain LOD to show. Value -1 disables this feature.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(60), Limit(-1, 100, 0.1f), EditorDisplay("Terrain", "Forced LOD"), Tooltip("Terrain forced Level Of Detail index. Allows to bind the given chunk LOD to show. Value -1 disables this feature.")]
        public int ForcedLOD
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetForcedLOD(unmanagedPtr); }
            set { Internal_SetForcedLOD(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain LODs distribution parameter. Adjusts terrain chunks transitions distances.
        /// </summary>
        /// <remarks>
        /// Use lower value to increase terrain quality or higher value to increase performance. Default value is 0.6.
        /// </remarks>
        [UnmanagedCall]
        [EditorOrder(70), Limit(0, 5, 0.01f), EditorDisplay("Terrain", "LOD Distribution"), Tooltip("Terrain LODs distribution parameter. Adjusts terrain chunks transitions distances. Use lower value to increase terrain quality or higher value to increase performance. Default value is 0.75.")]
        public float LODDistribution
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLODDistribution(unmanagedPtr); }
            set { Internal_SetLODDistribution(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the default material used for terrain rendering (chunks can override this).
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(100), EditorDisplay("Terrain"), Tooltip("The default material used for terrain rendering (chunks can override this).")]
        public MaterialBase Material
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetMaterial(unmanagedPtr); }
            set { Internal_SetMaterial(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain scale in lightmap (applied to all the chunks).
        /// </summary>
        /// <remarks>
        /// Use value higher than 1 to increase baked lighting resolution.
        /// </remarks>
        [UnmanagedCall]
        [EditorOrder(110), Limit(0, 10000, 0.1f), EditorDisplay("Terrain", "Scale In Lightmap"), Tooltip("Terrain scale in lightmap (applied to all the chunks). Use value higher than 1 to increase baked lighting resolution.")]
        public float ScaleInLightmap
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetScaleInLightmap(unmanagedPtr); }
            set { Internal_SetScaleInLightmap(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain chunks bounds extent. Values used to expand terrain chunks bounding boxes. Use it when your terrain material is performing vertex offset operations on a GPU.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(120), EditorDisplay("Terrain"), Tooltip("Terrain chunks bounds extent. Values used to expand terrain chunks bounding boxes. Use it when your terrain material is performing vertex offset operations on a GPU.")]
        public Vector3 BoundsExtent
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector3 resultAsRef; Internal_GetBoundsExtent(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetBoundsExtent(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain geometry LOD index used for collision.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(500), Limit(-1, 100, 0.1f), EditorDisplay("Collision", "Collision LOD"), Tooltip("Terrain geometry LOD index used for collision.")]
        public int CollisionLOD
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetCollisionLOD(unmanagedPtr); }
            set { Internal_SetCollisionLOD(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain holes threshold value. Uses terrain vertices visibility mask to create holes where visibility is lower than the given threshold. Value equal 0 disables holes feature..
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(510), Limit(0, 1, 0.01f), EditorDisplay("Collision"), Tooltip("Terrain holes threshold value. Uses terrain vertices visibility mask to create holes where visibility is lower than the given threshold. Value equal 0 disables holes feature.")]
        public float HolesThreshold
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetHolesThreshold(unmanagedPtr); }
            set { Internal_SetHolesThreshold(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the default physical material used to define the terrain collider physical properties.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(520), Limit(-1, 100, 0.1f), EditorDisplay("Collision"), AssetReference(typeof(PhysicalMaterial), true), Tooltip("Terrain default physical material used to define the collider physical properties.")]
        public JsonAsset PhysicalMaterial
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetPhysicalMaterial(unmanagedPtr); }
            set { Internal_SetPhysicalMaterial(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// Gets the terrain Level Of Detail count.
        /// </summary>
        [UnmanagedCall]
        public int LODCount
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLODCount(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the terrain chunk quads amount per edge (square).
        /// </summary>
        [UnmanagedCall]
        public int ChunkSize
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetChunkSize(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the terrain patches count. Each patch contains 16 chunks arranged into a 4x4 square.
        /// </summary>
        [UnmanagedCall]
        public int PatchesCount
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetPatchesCount(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Check if terrain has the patch at the given coordinates.
        /// </summary>
        /// <param name="patchCoord">The patch location (x and z coordinates).</param>
        /// <returns>True if has patch added, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public bool HasPatch(ref Int2 patchCoord)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_HasPatch(unmanagedPtr, ref patchCoord);
#endif
        }

        /// <summary>
        /// Gets the terrain patch coordinates (x and z) at the given index.
        /// </summary>
        /// <param name="patchIndex">The zero-based index of the terrain patch in the terrain patches collection.</param>
        /// <param name="patchCoord">The patch location (x and z coordinates).</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void GetPatchCoord(int patchIndex, out Int2 patchCoord)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_GetPatchCoord(unmanagedPtr, patchIndex, out patchCoord);
#endif
        }

        /// <summary>
        /// Gets the terrain patch world bounds at the given index.
        /// </summary>
        /// <param name="patchIndex">The zero-based index of the terrain patch in the terrain patches collection.</param>
        /// <param name="bounds">The patch world bounds.</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void GetPatchBounds(int patchIndex, out BoundingBox bounds)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_GetPatchBounds(unmanagedPtr, patchIndex, out bounds);
#endif
        }

        /// <summary>
        /// Gets the terrain chunk world bounds at the given index.
        /// </summary>
        /// <param name="patchIndex">The zero-based index of the terrain patch in the terrain patches collection.</param>
        /// <param name="chunkIndex">The zero-based index of the terrain chunk in the terrain patches collection.</param>
        /// <param name="bounds">The chunk world bounds.</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void GetChunkBounds(int patchIndex, int chunkIndex, out BoundingBox bounds)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_GetChunkBounds(unmanagedPtr, patchIndex, chunkIndex, out bounds);
#endif
        }

        /// <summary>
        /// Creates the terrain.
        /// </summary>
        /// <param name="lodCount">The LODs count. The actual amount of LODs may be lower due to provided chunk size (each LOD has 4 times less quads).</param>
        /// <param name="chunkSize">The size of the chunk (amount of quads per edge for the highest LOD). Must be power of two minus one (eg. 63 or 127).</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void Setup(int lodCount = 6, int chunkSize = 127)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Setup(unmanagedPtr, lodCount, chunkSize);
#endif
        }

        /// <summary>
        /// Adds the patch.
        /// </summary>
        /// <param name="patchCoord">The patch location (x and z coordinates).</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void AddPatch(ref Int2 patchCoord)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_AddPatch(unmanagedPtr, ref patchCoord);
#endif
        }

        /// <summary>
        /// Removes the patch.
        /// </summary>
        /// <param name="patchCoord">The patch location (x and z coordinates).</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void RemovePatch(ref Int2 patchCoord)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_RemovePatch(unmanagedPtr, ref patchCoord);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetLODBias(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLODBias(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetForcedLOD(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetForcedLOD(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetLODDistribution(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLODDistribution(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern MaterialBase Internal_GetMaterial(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetMaterial(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetScaleInLightmap(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetScaleInLightmap(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetBoundsExtent(IntPtr obj, out Vector3 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetBoundsExtent(IntPtr obj, ref Vector3 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetCollisionLOD(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetCollisionLOD(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetHolesThreshold(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetHolesThreshold(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern JsonAsset Internal_GetPhysicalMaterial(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetPhysicalMaterial(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetLODCount(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetChunkSize(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetPatchesCount(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_HasPatch(IntPtr obj, ref Int2 patchCoord);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetPatchCoord(IntPtr obj, int patchIndex, out Int2 patchCoord);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetPatchBounds(IntPtr obj, int patchIndex, out BoundingBox bounds);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetChunkBounds(IntPtr obj, int patchIndex, int chunkIndex, out BoundingBox bounds);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Setup(IntPtr obj, int lodCount, int chunkSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_AddPatch(IntPtr obj, ref Int2 patchCoord);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_RemovePatch(IntPtr obj, ref Int2 patchCoord);
#endif

        #endregion
    }
}
