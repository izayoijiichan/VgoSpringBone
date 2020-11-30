// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : VgoSpringBoneGroup
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// VGO Spring Bone Group
    /// </summary>
    /// <remarks>
    /// DefaultExecutionOrder(11000) means calculate springbone after FinalIK( VRIK )
    /// </remarks>
    [AddComponentMenu("Vgo/VgoSpringBoneGroup")]
    [DefaultExecutionOrder(11000)]
    public class VgoSpringBoneGroup : MonoBehaviour
    {
        /// <summary>Comments on this component.</summary>
        [SerializeField]
        public string comment;

        [Header("Settings")]

        /// <summary>The drag force.</summary>
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float dragForce = 0.4f;

        /// <summary>The stiffness force.</summary>
        [SerializeField]
        [Range(0.0f, 4.0f)]
        public float stiffnessForce = 1.0f;

        /// <summary>Direction of gravity.</summary>
        [SerializeField]
        public Vector3 gravityDirection = new Vector3(0, -1.0f, 0);

        /// <summary></summary>
        [SerializeField]
        [Range(0.0f, 2.0f)]
        public float gravityPower = 0.2f;

        ///// <summary></summary>
        //[SerializeField]
        //public Transform center = null;

        /// <summary>An array of the root spring bone transform.</summary>
        [SerializeField]
        public Transform[] rootBones = null;

        /// <summary></summary>
        public List<SpringBoneData>[] rootDatas;

        [Header("Collision")]

        /// <summary></summary>
        [SerializeField]
        [Range(0.0f, 0.5f)]
        public float hitRadius = 0.02f;

        /// <summary>An array of the spring bone collider group.</summary>
        [SerializeField]
        public VgoSpringBoneColliderGroup[] colliderGroups = null;

        /// <summary>Array of the spring bone internal collider.</summary>
        private readonly List<SpringBoneInternalCollider> colliders = new List<SpringBoneInternalCollider>();

        [Header("Gizmo")]

        /// <summary>Whether to draw Gizmo.</summary>
        [SerializeField]
        public bool drawGizmo = false;

        /// <summary>The Gizmo color.</summary>
        [SerializeField]
        public Color gizmoColor = Color.yellow;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            if (rootBones == null)
            {
                return;
            }

            Setup();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FixedUpdate()
        {
            if (rootBones == null)
            {
                return;
            }

            if (rootDatas == null)
            {
                return;
            }

            CollectColliders();

            float deltaTime = Time.deltaTime;

            float deltaStiffnessForce = stiffnessForce * deltaTime;
            Vector3 deltaGravityForce = gravityDirection * (gravityPower * deltaTime);

            for (int rootIndex = 0; rootIndex < rootDatas.Length; rootIndex++)
            {
                // @notice Count - 1
                for (int boneIndex = 0; boneIndex < rootDatas[rootIndex].Count - 1; boneIndex++)
                {
                    SpringBoneData boneData = rootDatas[rootIndex][boneIndex];

                    var verlet = boneData.verlet;
                    
                    verlet.headTransform = new SpringBoneTransformAccess(boneData.headTransform);
                    verlet.parentRotation = boneData.parentTransform == null ? Quaternion.identity : boneData.parentTransform.rotation;
                    verlet.currentTailPosition = boneData.currentTailPosition;
                    verlet.previousTailPosition = boneData.previousTailPosition;
                    verlet.stiffnessForce = deltaStiffnessForce;
                    verlet.dragForce = dragForce;
                    verlet.externalForce = deltaGravityForce;
                    //verlet.colliderGroups = colliderGroups;
                    verlet.colliders = colliders;
                    verlet.hitRadius = hitRadius;

                    verlet.Calculate();

                    boneData.headTransform.rotation = verlet.headTransformRotation;

                    boneData.previousTailPosition = verlet.currentTailPosition;
                    boneData.currentTailPosition = verlet.nextTailPosition;
                }
            }
        }

        /// <summary>
        /// Collect colliders into one list.
        /// </summary>
        private void CollectColliders()
        {
            if (colliders.Count > 0)
            {
                colliders.Clear();
            }

            foreach (var group in colliderGroups)
            {
                if (group == null)
                {
                    continue;
                }

                foreach (SpringBoneCollider collider in group.colliders)
                {
                    if (collider == null)
                    {
                        continue;
                    }

                    colliders.Add(new SpringBoneInternalCollider(group.transform, collider));
                }
            }
        }

        /// <summary>
        /// Set up the root bone and its child bones data.
        /// </summary>
        private void Setup()
        {
            rootDatas = new List<SpringBoneData>[rootBones.Length];

            for (int rootIndex = 0; rootIndex < rootBones.Length; rootIndex++)
            {
                if (rootBones[rootIndex] == null)
                {
                    continue;
                }

                rootDatas[rootIndex] = new List<SpringBoneData>();

                SetupRecursive(rootIndex, rootBones[rootIndex]);
            }

            for (int rootIndex = 0; rootIndex < rootDatas.Length; rootIndex++)
            {
                // @notice Count - 1
                for (int boneIndex = 0; boneIndex < rootDatas[rootIndex].Count - 1; boneIndex++)
                {
                    SpringBoneData boneData = rootDatas[rootIndex][boneIndex];

                    boneData.parentTransform = boneData.headTransform.parent;
                    boneData.tailTransform = rootDatas[rootIndex][boneIndex + 1].headTransform;
                    boneData.boneAxis = boneData.tailTransform.localPosition.normalized;
                    boneData.boneLength = boneData.tailTransform.localPosition.magnitude;
                    boneData.currentTailPosition = boneData.tailTransform.position;
                    boneData.previousTailPosition = boneData.currentTailPosition;
                    boneData.verlet = new SpringBoneVerlet(boneData.boneAxis, boneData.boneLength, hitRadius);
                }
            }
        }

        /// <summary>
        /// Set up child bones recursively.
        /// </summary>
        /// <param name="rootIndex"></param>
        /// <param name="transform"></param>
        private void SetupRecursive(int rootIndex, Transform transform)
        {
            rootDatas[rootIndex].Add(new SpringBoneData { headTransform = transform });

            if (transform.childCount > 0)
            {
                Transform firstChild = transform.GetChild(0);

                SetupRecursive(rootIndex, firstChild);
            }
        }

        /// <summary>
        /// Called when Gizmo is drawn.
        /// </summary>
        private void OnDrawGizmos()
        {
            if (drawGizmo)
            {
                if (rootDatas == null)
                {
                    return;
                }

                for (int rootIndex = 0; rootIndex < rootDatas.Length; rootIndex++)
                {
                    // @notice Count - 1
                    for (int boneIndex = 0; boneIndex < rootDatas[rootIndex].Count - 1; boneIndex++)
                    {
                        rootDatas[rootIndex][boneIndex].verlet.DrawGizmo(gizmoColor);
                    }
                }
            }
        }
    }
}
