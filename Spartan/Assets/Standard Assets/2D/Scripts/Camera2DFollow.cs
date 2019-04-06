
using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float mOffsetZ;
        private Vector3 mLastTargetPosition;
        private Vector3 mCurrentVelocity;
        private Vector3 mLookAheadPos;

        // Use this for initialization
        private void Start()
        {
            mLastTargetPosition = target.position;
            mOffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - mLastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                mLookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                mLookAheadPos = Vector3.MoveTowards(mLookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + mLookAheadPos + Vector3.forward*mOffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref mCurrentVelocity, damping);

            transform.position = newPos;

            mLastTargetPosition = target.position;
        }
    }
}
