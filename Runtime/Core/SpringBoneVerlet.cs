// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : SpringBoneVerlet
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Spring Bone Verlet
    /// </summary>
    /// <remarks>
    /// The base algorithm
    /// http://rocketjump.skr.jp/unity3d/109/ of @ricopin416
    /// </remarks>
    public class SpringBoneVerlet
    {
        /// <summary></summary>
        public SpringBoneTransformAccess headTransform;

        ///// <summary></summary>
        //public SpringBoneTransformAccess tailTransform;

        /// <summary>The bone axis.</summary>
        public Vector3 boneAxis;

        /// <summary>The bone length.</summary>
        public float boneLength;

        /// <summary>The parent bone rotation.</summary>
        public Quaternion parentRotation;

        /// <summary></summary>
        public Vector3 previousTailPosition;

        /// <summary></summary>
        public Vector3 currentTailPosition;

        /// <summary></summary>
        public Vector3 nextTailPosition;

        /// <summary>The drag force.</summary>
        public float dragForce;

        /// <summary>The stiffness force.</summary>
        public float stiffnessForce;

        /// <summary></summary>
        public Vector3 externalForce;

        ///// <summary>An array of spring bone collider.</summary>
        //public VgoSpringBoneColliderGroup[] colliderGroups;

        /// <summary>List of spring bone collider.</summary>
        public List<SpringBoneInternalCollider> colliders;

        /// <summary></summary>
        public float hitRadius;

        /// <summary>Whether the collider was a hit.</summary>
        public bool isHit;

        /// <summary>The head transform rotation.</summary>
        public Quaternion headTransformRotation;

        /// <summary>
        /// Create a new instance of SpringBoneVerlet with boneAxis and boneLength and hitRadius.
        /// </summary>
        /// <param name="boneAxis"></param>
        /// <param name="boneLength"></param>
        /// <param name="hitRadius"></param>
        public SpringBoneVerlet(Vector3 boneAxis, float boneLength, float hitRadius)
        {
            this.boneAxis = boneAxis;
            this.boneLength = boneLength;
            this.hitRadius = hitRadius;
        }

        /// <summary>
        /// Calculate next tail position.
        /// </summary>
        public void Calculate()
        {
            // verlet積分で次の位置を計算
            nextTailPosition = currentTailPosition
                + (currentTailPosition - previousTailPosition) * (1.0f - dragForce) // 前フレームの移動を継続する(減衰もあるよ)
                + parentRotation * headTransform.localRotation * boneAxis * stiffnessForce // 親の回転による子ボーンの移動目標
                + externalForce // 外力による移動量
                ;

            // 長さをboneLengthに強制
            nextTailPosition = headTransform.position + (nextTailPosition - headTransform.position).normalized * boneLength;

            // 衝突判定
            isHit = DetectCollision(ref nextTailPosition);

            Quaternion aimVector = parentRotation * headTransform.localRotation;
            Quaternion aimRotation = Quaternion.FromToRotation(aimVector * boneAxis, nextTailPosition - headTransform.position);

            headTransformRotation = aimRotation * headTransform.rotation;
        }

        /// <summary>
        /// Detects collision.
        /// </summary>
        /// <param name="nextTailPosition"></param>
        /// <returns></returns>
        private bool DetectCollision(ref Vector3 nextTailPosition)
        {
            foreach (SpringBoneInternalCollider collider in colliders)
            {
                float r = hitRadius + collider.radius;
                float sqrRadius = r * r;
                Vector3 ab = nextTailPosition - collider.position;
                float sqrMagnitude = Vector3.SqrMagnitude(ab);

                if (sqrMagnitude <= sqrRadius)
                {
                    // Colliderの半径方向に押し出す
                    Vector3 posFromCollider = collider.position + ab.normalized * r;

                    // 長さをboneLengthに強制
                    nextTailPosition = headTransform.position + (posFromCollider - headTransform.position).normalized * boneLength;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Draw Gizmo.
        /// </summary>
        /// <param name="color"></param>
        public void DrawGizmo(Color color)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(currentTailPosition, previousTailPosition);
            Gizmos.DrawWireSphere(previousTailPosition, hitRadius);

            Gizmos.color = color;
            Gizmos.DrawLine(currentTailPosition, headTransform.position);
            Gizmos.DrawWireSphere(currentTailPosition, hitRadius);
        }
    }
}
