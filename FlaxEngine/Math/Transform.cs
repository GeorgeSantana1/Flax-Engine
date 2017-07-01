﻿// Flax Engine scripting API

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FlaxEngine
{
    /// <summary>
    /// Represents a three dimensional mathematical transformation.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Transform : IEquatable<Transform>, IFormattable
    {
        private static readonly string _formatString = "Translation:{0} Orientation:{1} Scale:{2}";

        /// <summary>
        /// The size of the <see cref="Transform" /> type, in bytes
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf(typeof(Transform));

        /// <summary>
        /// A identity <see cref="Transform" /> with all default values
        /// </summary>
        public static readonly Transform Identity = new Transform(Vector3.Zero);

        /// <summary>
        /// Translation vector of the transform
        /// </summary>
        public Vector3 Translation;

        /// <summary>
        /// Rotation of the transform
        /// </summary>
        public Quaternion Orientation;

        /// <summary>
        /// Scale vector of the transform
        /// </summary>
        public Vector3 Scale;

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="position">Position in 3D space</param>
        public Transform(Vector3 position)
        {
            Translation = position;
            Orientation = Quaternion.Identity;
            Scale = Vector3.One;
        }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="position">Position in 3D space</param>
        /// <param name="rotation">Rotation in 3D space</param>
        public Transform(Vector3 position, Quaternion rotation)
        {
            Translation = position;
            Orientation = rotation;
            Scale = Vector3.One;
        }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="position">Position in 3D space</param>
        /// <param name="rotation">Rotation in 3D space</param>
        /// <param name="scale">Transform scale</param>
        public Transform(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Translation = position;
            Orientation = rotation;
            Scale = scale;
        }

        /// <summary>
        /// Gets a value indicting whether this transform is identity
        /// </summary>
        public bool IsIdentity
        {
            get { return Equals(Identity); }
        }

        /// <summary>
        /// Gets the forward vector.
        /// </summary>
        /// <value>
        /// The forward vector.
        /// </value>
        public Vector3 Forward => Vector3.Transform(Vector3.ForwardLH, Orientation);

        /// <summary>
        /// Gets the backward vector.
        /// </summary>
        /// <value>
        /// The backward vector.
        /// </value>
        public Vector3 Backward => Vector3.Transform(Vector3.BackwardLH, Orientation);

        /// <summary>
        /// Gets the up vector.
        /// </summary>
        /// <value>
        /// The up vector.
        /// </value>
        public Vector3 Up => Vector3.Transform(Vector3.Up, Orientation);

        /// <summary>
        /// Gets the down vector.
        /// </summary>
        /// <value>
        /// The down vector.
        /// </value>
        public Vector3 Down => Vector3.Transform(Vector3.Down, Orientation);

        /// <summary>
        /// Gets the left vector.
        /// </summary>
        /// <value>
        /// The left vector.
        /// </value>
        public Vector3 Left => Vector3.Transform(Vector3.Left, Orientation);

        /// <summary>
        /// Gets the right vector.
        /// </summary>
        /// <value>
        /// The right vector.
        /// </value>
        public Vector3 Right => Vector3.Transform(Vector3.Right, Orientation);

        /// <summary>
        /// Gets rotation matrix (from Orientation).
        /// </summary>
        /// <returns>Rotation matrix</returns>
        public Matrix GetRotation()
        {
            Matrix result;
            Matrix.RotationQuaternion(ref Orientation, out result);
            return result;
        }

        /// <summary>
        /// Gets rotation matrix (from Orientation).
        /// </summary>
        /// <param name="result">Matrix to set</param>
        public void GetRotation(out Matrix result)
        {
            Matrix.RotationQuaternion(ref Orientation, out result);
        }

        /// <summary>
        /// Sets rotation matrix (from Orientation).
        /// </summary>
        /// <param name="value">Rotation matrix</param>
        public void SetRotation(Matrix value)
        {
            Quaternion.RotationMatrix(ref value, out Orientation);
        }
        
        /// <summary>
        /// Sets rotation matrix (from Orientation).
        /// </summary>
        /// <param name="value">Rotation matrix</param>
        public void SetRotation(ref Matrix value)
        {
            Quaternion.RotationMatrix(ref value, out Orientation);
        }

        /// <summary>
        /// Gets world matrix that describes transformation as a 4 by 4 matrix.
        /// </summary>
        /// <returns>World matrix</returns>
        public Matrix GetWorld()
        {
            Matrix m1, m2, result;
            Matrix.Scaling(ref Scale, out result);
            Matrix.RotationQuaternion(ref Orientation, out m2);
            Matrix.Multiply(ref result, ref m2, out m1);
            Matrix.Translation(ref Translation, out m2);
            Matrix.Multiply(ref m1, ref m2, out result);
            return result;
        }

        /// <summary>
        /// Gets world matrix that describes transformation as a 4 by 4 matrix.
        /// </summary>
        /// <param name="result">World matrix</param>
        public void GetWorld(out Matrix result)
        {
            Matrix m1, m2;
            Matrix.Scaling(ref Scale, out result);
            Matrix.RotationQuaternion(ref Orientation, out m2);
            Matrix.Multiply(ref result, ref m2, out m1);
            Matrix.Translation(ref Translation, out m2);
            Matrix.Multiply(ref m1, ref m2, out result);
        }


        /// <summary>
        /// Perform tranformation of the given transform in local space
        /// </summary>
        /// <param name="other">Local space transform</param>
        /// <returns>World space transform</returns>
        public Transform LocalToWorld(Transform other)
        {
            Transform result = new Transform(Vector3.Zero);

            // Orientation
            Quaternion.Multiply(ref other.Orientation, ref Orientation, out result.Orientation);

            // Scale
            Vector3.Multiply(ref other.Scale, ref Scale, out result.Scale);

            // Translation
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            Vector3.Transform(ref other.Translation, ref scaleRotation, out result.Translation);
            result.Translation += Translation;

            return result;
        }

        /// <summary>
        /// Perform tranformation of the given point in local space
        /// </summary>
        /// <param name="point">Local space point</param>
        /// <returns>World space point</returns>
        public Vector3 LocalToWorld(Vector3 point)
        {
            Vector3 result;
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            Vector3.Transform(ref point, ref scaleRotation, out result);
            return result + Translation;
        }

        /// <summary>
        /// Perform tranformation of the given points in local space
        /// </summary>
        /// <param name="points">Local space points</param>
        /// <param name="result">World space points</param>
        public void LocalToWorld(Vector3[] points, Vector3[] result)
        {
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            for (int i = 0; i < points.Length; i++)
                result[i] = Vector3.Transform(points[i], scaleRotation) + Translation;
        }

        /// <summary>
        /// Perform tranformation of the given transform in world space
        /// </summary>
        /// <param name="other">World space transform</param>
        /// <returns>Local space transform</returns>
        public Transform WorldToLocal(Transform other)
        {
            Transform result = new Transform(Vector3.Zero);

            // Orientation
            Quaternion.Divide(ref other.Orientation, ref Orientation, out result.Orientation);

            // Scale
            Vector3.Divide(ref other.Scale, ref Scale, out result.Scale);

            // Translation
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            Matrix.Invert(ref scaleRotation, out scale);
            result.Translation = other.Translation - Translation;
            Vector3.Transform(ref result.Translation, ref scale, out result.Translation);

            return result;
        }

        /// <summary>
        /// Perform tranformation of the given point in world space
        /// </summary>
        /// <param name="point">World space point</param>
        /// <returns>Local space point</returns>
        public Vector3 WorldToLocal(Vector3 point)
        {
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            Matrix.Invert(ref scaleRotation, out scale);
            Vector3 result = point - Translation;
            Vector3.Transform(ref result, ref scale, out result);
            return result;
        }

        /// <summary>
        /// Perform tranformation of the given points in world space
        /// </summary>
        /// <param name="points">World space points</param>
        /// <param name="result">Local space points</param>
        public void WorldToLocal(Vector3[] points, Vector3[] result)
        {
            Matrix scale, rotation, scaleRotation;
            Matrix.Scaling(ref Scale, out scale);
            Matrix.RotationQuaternion(ref Orientation, out rotation);
            Matrix.Multiply(ref scale, ref rotation, out scaleRotation);
            Matrix.Invert(ref scaleRotation, out scale);
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = points[i] - Translation;
                Vector3.Transform(ref result[i], ref scale, out result[i]);
            }
        }

        /// <summary>
        /// Performs a linear interpolation between two transformations.
        /// </summary>
        /// <param name="start">Start transformation.</param>
        /// <param name="end">End transformation.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end" />.</param>
        /// <returns>The linear interpolation of the two transformations.</returns>
        /// <remarks>
        /// Passing <paramref name="amount" /> a value of 0 will cause <paramref name="start" /> to be returned; a value of 1
        /// will cause <paramref name="end" /> to be returned.
        /// </remarks>
        public static Transform Lerp(Transform start, Transform end, float amount)
        {
            Transform result;
            Vector3.Lerp(ref start.Translation, ref end.Translation, amount, out result.Translation);
            Quaternion.Lerp(ref start.Orientation, ref end.Orientation, amount, out result.Orientation);
            Vector3.Lerp(ref start.Scale, ref end.Scale, amount, out result.Scale);
            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two transformations.
        /// </summary>
        /// <param name="start">Start transformation.</param>
        /// <param name="end">End transformation.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end" />.</param>
        /// <param name="result">When the method completes, contains the linear interpolation of the two transformations.</param>
        /// <remarks>
        /// Passing <paramref name="amount" /> a value of 0 will cause <paramref name="start" /> to be returned; a value of 1
        /// will cause <paramref name="end" /> to be returned.
        /// </remarks>
        public static void Lerp(ref Transform start, ref Transform end, float amount, out Transform result)
        {
            Vector3.Lerp(ref start.Translation, ref end.Translation, amount, out result.Translation);
            Quaternion.Lerp(ref start.Orientation, ref end.Orientation, amount, out result.Orientation);
            Vector3.Lerp(ref start.Scale, ref end.Scale, amount, out result.Scale);
        }

        /// <summary>
        /// Tests for equality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="left" /> has the same value as <paramref name="right" />; otherwise,
        /// <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Transform left, Transform right)
        {
            return left.Equals(ref right);
        }

        /// <summary>
        /// Tests for inequality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="left" /> has a different value than <paramref name="right" />; otherwise,
        /// <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Transform left, Transform right)
        {
            return !left.Equals(ref right);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, _formatString, Translation, Orientation, Scale);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            if (format == null)
                return ToString();

            return string.Format(CultureInfo.CurrentCulture, _formatString,
                Translation.ToString(format, CultureInfo.CurrentCulture),
                Orientation.ToString(format, CultureInfo.CurrentCulture),
                Scale.ToString(format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, _formatString, Translation, Orientation, Scale);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString(formatProvider);

            return string.Format(formatProvider, _formatString,
                Translation.ToString(format, formatProvider),
                Orientation.ToString(format, formatProvider),
                Scale.ToString(format, formatProvider));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Translation.GetHashCode();
                hashCode = (hashCode * 397) ^ Orientation.GetHashCode();
                hashCode = (hashCode * 397) ^ Scale.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="Transform" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Transform" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Transform" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ref Transform other)
        {
            return Translation == other.Translation
                   && Orientation == other.Orientation
                   && Scale == other.Scale;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Transform" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Transform" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Transform" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Transform other)
        {
            return Equals(ref other);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="value">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object value)
        {
            if (!(value is Transform))
                return false;

            var strongValue = (Transform)value;
            return Equals(ref strongValue);
        }
    }
}
