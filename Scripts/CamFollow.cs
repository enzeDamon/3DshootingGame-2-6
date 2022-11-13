using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // this marks the distance between camera and player
    private Vector3 distance;
    private Transform m_FollowTarget;
    // Start is called before the first frame update
    void Start()
    {
        m_FollowTarget = GameObject.Find("Player").gameObject.transform;
        distance = m_FollowTarget.position - transform.position;
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = m_FollowTarget.position - distance;
    }
}
