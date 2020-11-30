// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Struct     : SpringBoneInternalCollider
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using UnityEngine;

    /// <summary>
    /// Spring Bone Internal Collider
    /// </summary>
    public struct SpringBoneInternalCollider
    {
        /// <summary>The type of the spring bone collider.</summary>
        public SpringBoneColliderType colliderType;

        /// <summary>The position of the transform in world space.</summary>
        public Vector3 position;

        /// <summary>The radius of the collider.</summary>
        public float radius;

        /// <summary>
        /// Create a new instance of SpringBoneInternalCollider with transform and collider.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="collider"></param>
        public SpringBoneInternalCollider(Transform transform, SpringBoneCollider collider)
        {
            colliderType = collider.colliderType;

            position = transform.TransformPoint(collider.offset);

            float scale = Mathf.Max(
                transform.lossyScale.x,
                Mathf.Max(
                transform.lossyScale.y,
                transform.lossyScale.z
            ));

            radius = scale * collider.radius;
        }
    }
}
