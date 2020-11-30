// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : SpringBoneTransformAccess
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using UnityEngine;

    /// <summary>
    /// Spring Bone Transform Access
    /// </summary>
    public struct SpringBoneTransformAccess
    {
        /// <summary>The position of the transform in world space.</summary>
        public Vector3 position;

        /// <summary>The rotation of the transform in world space stored as a Quaternion.</summary>
        public Quaternion rotation;

        /// <summary>The position of the transform relative to the parent.</summary>
        public Vector3 localPosition;

        /// <summary>The rotation of the transform relative to the parent transform's rotation.</summary>
        public Quaternion localRotation;

        /// <summary>The scale of the transform relative to the parent.</summary>
        public Vector3 localScale;

        /// <summary>
        /// Create a new instance of SpringBoneTransformAccess with transform.
        /// </summary>
        /// <param name="transform"></param>
        public SpringBoneTransformAccess(Transform transform)
        {
            position = transform.position;
            rotation = transform.rotation;
            localPosition = transform.localPosition;
            localRotation = transform.localRotation;
            localScale = transform.localScale;
        }
    }
}
