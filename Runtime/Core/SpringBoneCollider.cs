// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : SpringBoneCollider
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Spring Bone Collider
    /// </summary>
    [Serializable]
    public class SpringBoneCollider
    {
        /// <summary>The type of the spring bone collider.</summary>
        public SpringBoneColliderType colliderType;

        /// <summary>The offset position from the game object.</summary>
        public Vector3 offset;

        /// <summary>The radius of the collider.</summary>
        [Range(0.0f, 1.0f)]
        public float radius;

        /// <summary>
        /// Create a new instance of SpringBoneCollider.
        /// </summary>
        public SpringBoneCollider()
        {
        }

        /// <summary>
        /// Create a new instance of SpringBoneCollider with colliderType.
        /// </summary>
        /// <param name="colliderType"></param>
        public SpringBoneCollider(SpringBoneColliderType colliderType)
        {
            this.colliderType = colliderType;
        }

        /// <summary>
        /// Create a new instance of SpringBoneCollider with colliderType and offset and radius.
        /// </summary>
        /// <param name="colliderType"></param>
        /// <param name="offset"></param>
        /// <param name="radius"></param>
        public SpringBoneCollider(SpringBoneColliderType colliderType, Vector3 offset = default, float radius = default)
        {
            this.colliderType = colliderType;
            this.offset = offset;
            this.radius = radius;
        }
    }
}
