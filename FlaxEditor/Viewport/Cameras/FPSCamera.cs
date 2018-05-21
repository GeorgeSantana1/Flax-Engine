// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using FlaxEngine;

namespace FlaxEditor.Viewport.Cameras
{
	/// <summary>
	/// Implementation of <see cref="ViewportCamera"/> that simulated teh first-person ccamera which can fly though the scene.
	/// </summary>
	/// <seealso cref="FlaxEditor.Viewport.Cameras.ViewportCamera" />
	public class FPSCamera : ViewportCamera
	{
		private Transform _startMove;
		private Transform _endMove;
		private float _moveStartTime = -1;

		/// <summary>
		/// Gets a value indicating whether this viewport is animating movement.
		/// </summary>
		public bool IsAnimatingMove => _moveStartTime > Mathf.Epsilon;

		/// <summary>
		/// The target point location. It's used to orbit around it whe user clicks Alt+LMB.
		/// </summary>
		public Vector3 TargetPoint = new Vector3(-200);

		/// <summary>
		/// Sets view.
		/// </summary>
		/// <param name="position">The view position.</param>
		/// <param name="direction">The view direction.</param>
		public void SetView(Vector3 position, Vector3 direction)
		{
			if (IsAnimatingMove)
				return;

			// Rotate and move
			Viewport.ViewPosition = position;
			Viewport.ViewDirection = direction;
		}

		/// <summary>
		/// Sets view.
		/// </summary>
		/// <param name="position">The view position.</param>
		/// <param name="orientation">The view rotation.</param>
		public void SetView(Vector3 position, Quaternion orientation)
		{
			if (IsAnimatingMove)
				return;

			// Rotate and move
			Viewport.ViewPosition = position;
			Viewport.ViewOrientation = orientation;
		}

		/// <summary>
		/// Start animating viewport movement to the target transformation.
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <param name="orientation">The target orientation.</param>
		public void MoveViewport(Vector3 position, Quaternion orientation)
		{
			MoveViewport(new Transform(position, orientation));
		}

		/// <summary>
		/// Start animating viewport movement to the target transformation.
		/// </summary>
		/// <param name="target">The target transform.</param>
		public void MoveViewport(Transform target)
		{
			_startMove = Viewport.ViewTransform;
			_endMove = target;
			_moveStartTime = Time.UnscaledGameTime;
		}

		/// <inheritdoc />
		public override void Update(float deltaTime)
		{
			// Udate animated movement
			if (IsAnimatingMove)
			{
				// Calculate linear progress
				float animationDuration = 0.5f;
				float time = Time.UnscaledGameTime;
				float progress = (time - _moveStartTime) / animationDuration;

				// Check for end
				if (progress >= 1.0f)
				{
					// Animation has been finished
					_moveStartTime = -1;
				}

				// Animate camera
				float a = Mathf.Saturate(progress);
				a = a * a * a;
				Transform targetTransform = Transform.Lerp(_startMove, _endMove, a);
				targetTransform.Scale = Vector3.Zero;
				Viewport.ViewPosition = targetTransform.Translation;
				Viewport.ViewOrientation = targetTransform.Orientation;
			}
		}

		/// <inheritdoc />
		public override void UpdateView(float dt, ref Vector3 moveDelta, ref Vector2 mouseDelta)
		{
			if (IsAnimatingMove)
				return;

			EditorViewport.Input input;
			Viewport.GetInput(out input);

			// Get current view properties
			float yaw = Viewport.Yaw;
			float pitch = Viewport.Pitch;
			var position = Viewport.ViewPosition;
			var rotation = Viewport.ViewOrientation;

			// Compute base vectors for camera movement
			var forward = Vector3.Forward * rotation;
			var up = Vector3.Up * rotation;
			var right = Vector3.Cross(forward, up);

			// Dolly
			if (input.IsPanning || input.IsMoving || input.IsRotating)
			{
				Vector3 move;
				Vector3.Transform(ref moveDelta, ref rotation, out move);
				position += move;
			}

			// Pan
			if (input.IsPanning)
			{
				var panningSpeed = 0.8f;
				position -= right * (mouseDelta.X * panningSpeed);
				position -= up * (mouseDelta.Y * panningSpeed);
			}

			// Move
			if (input.IsMoving)
			{
				// Move camera over XZ plane
				var projectedForward = Vector3.Normalize(new Vector3(forward.X, 0, forward.Z));
				position -= projectedForward * mouseDelta.Y;
				yaw += mouseDelta.X;
			}

			// Rotate or orbit
			if (input.IsRotating || input.IsOrbiting)
			{
				yaw += mouseDelta.X;
				pitch += mouseDelta.Y;
			}

			// Zoom in/out
			if (input.IsZooming)
			{
				position += forward * (Viewport.MouseWheelZoomSpeedFactor * input.MouseWheelDelta * 25.0f);
				if (input.IsAltDown)
				{
					position += forward * (Viewport.MouseSpeed * 40 * Viewport.MouseDeltaRight.ValuesSum);
				}
			}

			// Update view
			Viewport.Yaw = yaw;
			Viewport.Pitch = pitch;
			if (input.IsOrbiting)
			{
				float orbitRadius = Vector3.Distance(position, TargetPoint);
				Vector3 localPosition = Viewport.ViewDirection * (-1 * orbitRadius);
				Viewport.ViewPosition = TargetPoint + localPosition;
			}
			else
			{
				TargetPoint += position - Viewport.ViewPosition;
				Viewport.ViewPosition = position;
			}
		}
	}
}