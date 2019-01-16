// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// The interface to get input information from Flax.
    /// </summary>
    public static partial class Input
    {
        /// <summary>
        /// Gets the text entered during the current frame (Unicode).
        /// </summary>
        [UnmanagedCall]
        public static string InputText
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetInputText(); }
#endif
        }

        /// <summary>
        /// Gets or sets the current mouse position.
        /// </summary>
        [UnmanagedCall]
        public static Vector2 MousePosition
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector2 resultAsRef; Internal_GetMousePosition(out resultAsRef); return resultAsRef; }
            set { Internal_SetMousePosition(ref value); }
#endif
        }

        /// <summary>
        /// Gets the mouse position delta during the last frame.
        /// </summary>
        [UnmanagedCall]
        public static Vector2 MousePositionDelta
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector2 resultAsRef; Internal_GetMousePositionDelta(out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Gets the mouse wheel delta during the last frame.
        /// </summary>
        [UnmanagedCall]
        public static float MouseScrollDelta
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetMouseScrollDelta(); }
#endif
        }

        /// <summary>
        /// Gets keyboard key state.
        /// </summary>
        /// <param name="key">Key to check.</param>
        /// <returns>True while the user holds down the key identified by id.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetKey(Keys key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetKey(key);
#endif
        }

        /// <summary>
        /// Gets keyboard key down state.
        /// </summary>
        /// <param name="key">Key to check.</param>
        /// <returns>True during the frame the user starts pressing down the key.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetKeyDown(Keys key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetKeyDown(key);
#endif
        }

        /// <summary>
        /// Gets keyboard key up state.
        /// </summary>
        /// <param name="key">Key to check.</param>
        /// <returns>True during the frame the user releases the key.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetKeyUp(Keys key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetKeyUp(key);
#endif
        }

        /// <summary>
        /// Gets mouse button state.
        /// </summary>
        /// <param name="button">Mouse button to check.</param>
        /// <returns>True while the user holds down the button.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetMouseButton(MouseButton button)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetMouseButton(button);
#endif
        }

        /// <summary>
        /// Gets mouse button down state.
        /// </summary>
        /// <param name="button">Mouse button to check.</param>
        /// <returns>True during the frame the user starts pressing down the button.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetMouseButtonDown(MouseButton button)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetMouseButtonDown(button);
#endif
        }

        /// <summary>
        /// Gets mouse button up state.
        /// </summary>
        /// <param name="button">Mouse button to check.</param>
        /// <returns>True during the frame the user releases the button.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static bool GetMouseButtonUp(MouseButton button)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetMouseButtonUp(button);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string Internal_GetInputText();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetMousePosition(out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetMousePosition(ref Vector2 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetMousePositionDelta(out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetMouseScrollDelta();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetKey(Keys key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetKeyDown(Keys key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetKeyUp(Keys key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetMouseButton(MouseButton button);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetMouseButtonDown(MouseButton button);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetMouseButtonUp(MouseButton button);
#endif

        #endregion
    }
}
