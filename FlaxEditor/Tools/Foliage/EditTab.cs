// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.

using System;
using FlaxEditor.CustomEditors;
using FlaxEditor.CustomEditors.Editors;
using FlaxEditor.GUI;
using FlaxEngine;

namespace FlaxEditor.Tools.Foliage
{
    /// <summary>
    /// Foliage instances editor tab. Allows to pick and edit a single foliage instance properties.
    /// </summary>
    /// <seealso cref="FlaxEditor.GUI.Tab" />
    public class EditTab : Tab
    {
        /// <summary>
        /// The object for foliage settings adjusting via Custom Editor.
        /// </summary>
        [CustomEditor(typeof(ProxyObjectEditor))]
        private sealed class ProxyObject
        {
            /// <summary>
            /// The selected foliage actor.
            /// </summary>
            [HideInEditor]
            public FlaxEngine.Foliage Foliage;

            /// <summary>
            /// The selected foliage instance index.
            /// </summary>
            [HideInEditor]
            public int InstanceIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProxyObject"/> class.
            /// </summary>
            public ProxyObject()
            {
                InstanceIndex = -1;
            }

            private FlaxEngine.Foliage.Instance _options;

            public void SyncOptions()
            {
                if (Foliage != null && InstanceIndex > -1 && InstanceIndex < Foliage.InstancesCount)
                {
                    Foliage.GetInstance(InstanceIndex, out _options);
                }
            }

            public void SetOptions()
            {
                if (Foliage != null && InstanceIndex > -1 && InstanceIndex < Foliage.InstancesCount)
                {
                    Foliage.SetInstance(InstanceIndex, ref _options);
                }
            }

            //

            [EditorOrder(-10), EditorDisplay("Instance"), ReadOnly, Tooltip("The foliage instance zero-based index (read-only).")]
            public int Index
            {
                get => InstanceIndex;
                set => throw new NotImplementedException();
            }

            [EditorOrder(0), EditorDisplay("Instance"), ReadOnly, Tooltip("The foliage instance model (read-only).")]
            public Model Model
            {
                get => Foliage.GetFoliageTypeModel(_options.Type);
                set => throw new NotImplementedException();
            }

            [EditorOrder(10), EditorDisplay("Instance"), Tooltip("The local-space position of the mesh relative to the foliage actor.")]
            public Vector3 Position
            {
                get => _options.Transform.Translation;
                set
                {
                    _options.Transform.Translation = value;
                    SetOptions();
                }
            }

            [EditorOrder(20), EditorDisplay("Instance"), Tooltip("The local-space rotation of the mesh relative to the foliage actor.")]
            public Quaternion Rotation
            {
                get => _options.Transform.Orientation;
                set
                {
                    _options.Transform.Orientation = value;
                    SetOptions();
                }
            }

            [EditorOrder(30), EditorDisplay("Instance"), Tooltip("The local-space scale of the mesh relative to the foliage actor.")]
            public Vector3 Scale
            {
                get => _options.Transform.Scale;
                set
                {
                    _options.Transform.Scale = value;
                    SetOptions();
                }
            }
        }

        /// <summary>
        /// The custom editor for <see cref="ProxyObject"/>.
        /// </summary>
        /// <seealso cref="FlaxEditor.CustomEditors.Editors.GenericEditor" />
        private sealed class ProxyObjectEditor : GenericEditor
        {
            // TODO: add remove button to delete selected instance - with undo

            /// <inheritdoc />
            public override void Refresh()
            {
                // Sync selected foliage options once before update to prevent too many data copies when fetching data from UI properties accessors
                var proxyObject = (ProxyObject)Values[0];
                proxyObject.SyncOptions();

                base.Refresh();
            }
        }

        private readonly ProxyObject _proxy;
        private readonly CustomEditorPresenter _presenter;

        /// <summary>
        /// The parent foliage tab.
        /// </summary>
        public readonly FoliageTab Tab;

        /// <summary>
        /// The related gizmo mode.
        /// </summary>
        public readonly EditFoliageGizmoMode Mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditTab"/> class.
        /// </summary>
        /// <param name="tab">The parent tab.</param>
        /// <param name="mode">The related gizmo mode.</param>
        public EditTab(FoliageTab tab, EditFoliageGizmoMode mode)
        : base("Edit")
        {
            Mode = mode;
            Tab = tab;
            Tab.SelectedFoliageChanged += OnSelectedFoliageChanged;
            mode.SelectedInstanceIndexChanged += OnSelectedInstanceIndexChanged;
            _proxy = new ProxyObject();

            // Options editor
            // TODO: use editor undo for changing foliage instance options
            var editor = new CustomEditorPresenter(null, "No foliage instance selected");
            editor.Panel.Parent = this;
            editor.Modified += OnModified;
            _presenter = editor;
        }

        private void OnSelectedInstanceIndexChanged()
        {
            _proxy.InstanceIndex = Mode.SelectedInstanceIndex;
            if (_proxy.InstanceIndex == -1)
            {
                _presenter.Deselect();
            }
            else
            {
                _presenter.Select(_proxy);
            }
        }

        private void OnModified()
        {
            Editor.Instance.Scene.MarkSceneEdited(_proxy.Foliage?.Scene);
        }

        private void OnSelectedFoliageChanged()
        {
            Mode.SelectedInstanceIndex = -1;
            _proxy.Foliage = Tab.SelectedFoliage;
        }
    }
}