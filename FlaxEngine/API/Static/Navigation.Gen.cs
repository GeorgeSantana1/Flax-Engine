// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// The navigation service used for path finding and agents navigation system.
    /// </summary>
    public static partial class Navigation
    {
        /// <summary>
        /// Returns true if navigation system is during navmesh building (any request is valid or async task active).
        /// </summary>
        [UnmanagedCall]
        public static bool IsBuildingNavMesh
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_IsBuildingNavMesh(); }
#endif
        }

        /// <summary>
        /// Gets the navmesh building progress (normalized to range 0-1).
        /// </summary>
        [UnmanagedCall]
        public static float NavMeshBuildingProgress
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetNavMeshBuildingProgress(); }
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_IsBuildingNavMesh();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetNavMeshBuildingProgress();
#endif

        #endregion
    }
}
