// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : VgoSpringBoneColliderGroup
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using UnityEngine;

    /// <summary>
    /// VGO Spring Bone Collider Group
    /// </summary>
    [AddComponentMenu("Vgo/Vgo Spring Bone Collider Group")]
    [DefaultExecutionOrder(11001)]
    [DisallowMultipleComponent]
    public class VgoSpringBoneColliderGroup : MonoBehaviour
    {
        [Header("Collision")]

        /// <summary>An array of the srping bone collider.</summary>
        [SerializeField]
        public SpringBoneCollider[] colliders = new SpringBoneCollider[]
        {
            new SpringBoneCollider(SpringBoneColliderType.Sphere, radius: 0.1f),
        };

        [Header("Gizmo")]

        /// <summary>The Gizmo color.</summary>
        [SerializeField]
        public Color gizmoColor = Color.magenta;

        /// <summary>
        /// 
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;

            Matrix4x4 worldMatrix = transform.localToWorldMatrix;

            float ls = Mathf.Max(
                transform.lossyScale.x,
                Mathf.Max(
                transform.lossyScale.y,
                transform.lossyScale.z
            ));

            Vector3 scale = new Vector3(
                1.0f / transform.lossyScale.x * ls,
                1.0f / transform.lossyScale.y * ls,
                1.0f / transform.lossyScale.z * ls
            );

            Gizmos.matrix = worldMatrix * Matrix4x4.Scale(scale);

            foreach (SpringBoneCollider collider in colliders)
            {
                if (collider.colliderType == SpringBoneColliderType.Sphere)
                {
                    Gizmos.DrawWireSphere(collider.offset, collider.radius);
                }
            }
        }
    }
}
