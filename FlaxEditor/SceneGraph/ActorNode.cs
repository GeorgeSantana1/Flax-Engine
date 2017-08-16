////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.SceneGraph.Actors;
using FlaxEditor.SceneGraph.GUI;
using FlaxEditor.Windows;
using FlaxEngine;

namespace FlaxEditor.SceneGraph
{
    /// <summary>
    /// A tree node used to visalize scene actors structure in <see cref="SceneTreeWindow"/>. It's a ViewModel object for <see cref="Actor"/>.
    /// It's part of the Scene Graph.
    /// </summary>
    /// <seealso cref="FlaxEngine.GUI.TreeNode" />
    /// <seealso cref="SceneGraphNode" />
    public class ActorNode : SceneGraphNode
    {
        /// <summary>
        /// The linked actor object.
        /// </summary>
        protected readonly Actor _actor;

        /// <summary>
        /// The tree node used to present hierachy structure in GUI.
        /// </summary>
        protected readonly ActorTreeNode _treeNode;

        /// <summary>
        /// Gets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        public Actor Actor => _actor;

        /// <summary>
        /// Gets the tree node (part of the GUI).
        /// </summary>
        /// <value>
        /// The tree node.
        /// </value>
        public ActorTreeNode TreeNode => _treeNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorNode"/> class.
        /// </summary>
        /// <param name="actor">The actor.</param>
        public ActorNode(Actor actor)
            : base(actor.ID)
        {
            _actor = actor;
            _treeNode = new ActorTreeNode(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorNode"/> class.
        /// </summary>
        /// <param name="actor">The actor.</param>
        /// <param name="treeNode">The custom tree node.</param>
        protected ActorNode(Actor actor, ActorTreeNode treeNode)
            : base(actor.ID)
        {
            _actor = actor;
            _treeNode = treeNode;
        }

        internal ActorNode(Actor actor, Guid id)
            : base(id)
        {
            _actor = actor;
            _treeNode = new ActorTreeNode(this);
        }

        /// <summary>
        /// Tries to find the tree node for the specified actor.
        /// </summary>
        /// <param name="actor">The actor.</param>
        /// <returns>Tree node or null if cannot find it.</returns>
        public ActorNode Find(Actor actor)
        {
            // Check itself
            if (_actor == actor)
                return this;

            // Check deeper
            for (int i = 0; i < ChildNodes.Count; i++)
            {
                if (ChildNodes[i] is ActorNode node)
                {
                    var result = node.Find(actor);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Tries to find the tree node for the specified actor in child nodes collection.
        /// </summary>
        /// <param name="actor">The actor.</param>
        /// <returns>Tree node or null if cannot find it.</returns>
        public ActorNode FindChild(Actor actor)
        {
            for (int i = 0; i < ChildNodes.Count; i++)
            {
                if (ChildNodes[i] is ActorNode node && node.Actor == actor)
                {
                    return node;
                }
            }

            return null;
        }

        /// <inheritdoc />
        public override string Name => _actor.Name;

        /// <inheritdoc />
        public override SceneNode ParentScene => SceneGraphFactory.FindNode(_actor.ID) as SceneNode;

        /// <inheritdoc />
        public override bool IsActive => _actor.IsActive;

        /// <inheritdoc />
        public override bool IsActiveInHierarchy => _actor.IsActiveInHierarchy;

        /// <inheritdoc />
        public override Transform Transform
        {
            get => _actor.Transform;
            set => _actor.Transform = value;
        }

        /// <inheritdoc />
        public override Vector3 Position
        {
            get => _actor.Position;
            set => _actor.Position = value;
        }

        /// <inheritdoc />
        public override Quaternion Orientation
        {
            get => _actor.Orientation;
            set => _actor.Orientation = value;
        }

        /// <inheritdoc />
        public override Vector3 Scale
        {
            get => _actor.Scale;
            set => _actor.Scale = value;
        }

        /// <inheritdoc />
        public override SceneGraphNode ParentNode
        {
            set
            {
                if (!(value is ActorNode))
                    throw new InvalidOperationException("ActorNode can have only ActorNode as a parent node.");

                base.ParentNode = value;
            }
        }

        /// <inheritdoc />
        public override object EditableObject => _actor;

        /// <inheritdoc />
        public override bool RayCastSelf(ref Ray ray, ref float distance)
        {
            return _actor.IntersectsItself(ref ray, ref distance);
        }

        /// <inheritdoc />
        protected override void OnParentChanged()
        {
            // Update UI node connections
            _treeNode.Parent = (ParentNode as ActorNode)?.TreeNode;

            // Check if it's a new node and parent has been already ready
            // (eg. we builded new node for spawned actor and link it to the game)
            if (_treeNode.Parent != null && !_treeNode.Parent.IsLayoutLocked)
            {
                _treeNode.Parent.SortChildren();

                // Update UI
                _treeNode.IsLayoutLocked = false;
                _treeNode.PerformLayout();
            }

            base.OnParentChanged();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            // Cleanup UI
            _treeNode.Dispose();

            base.Dispose();
        }
    }
}
