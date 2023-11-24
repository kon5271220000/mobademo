using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class movement : MonoBehaviour
{
    NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;

    float rotateVelocity;

    [SerializeField] private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) 
        {
            RaycastHit hit;

            //check if raycast shot sth that uses navmesh system;
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //player move to hit point
                agent.SetDestination(hit.point);

                //rotation
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));
            
                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}
