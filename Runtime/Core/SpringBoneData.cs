// ----------------------------------------------------------------------
// @Namespace : VgoSpringBone
// @Class     : SpringBoneData
// ----------------------------------------------------------------------
namespace VgoSpringBone
{
    using System;
    using UnityEngine;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SpringBoneData
    {
        /// <summary></summary>
        public Transform headTransform;

        /// <summary></summary>
        public Transform tailTransform;

        /// <summary></summary>
        public Transform parentTransform;

        /// <summary></summary>
        public Vector3 boneAxis;

        /// <summary></summary>
        public float boneLength;

        /// <summary></summary>
        public Vector3 previousTailPosition;

        /// <summary></summary>
        public Vector3 currentTailPosition;

        /// <summary></summary>
        public SpringBoneVerlet verlet;
    }
}
