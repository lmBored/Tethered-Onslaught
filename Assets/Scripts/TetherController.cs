using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject laserWhipPrefab;
    public GameObject stunTrapPrefab;

    private LineRenderer lineRenderer;
    private SpringJoint2D springJoint1;
    private SpringJoint2D springJoint2;
    private bool isLaserWhipActive = false;
    private bool isStunTrapActive = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        springJoint1 = player1.AddComponent<SpringJoint2D>();
        springJoint2 = player2.AddComponent<SpringJoint2D>();

        springJoint1.connectedBody = player2.GetComponent<Rigidbody2D>();
        springJoint2.connectedBody = player1.GetComponent<Rigidbody2D>();

        springJoint1.distance = 10f;
        springJoint2.distance = 10f;
    }

    void Update()
    {
        UpdateTetherPosition();

        if (Input.GetKeyDown(KeyCode.Alpha1) && !isLaserWhipActive)
        {
            StartCoroutine(ActivateLaserWhip());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !isStunTrapActive)
        {
            StartCoroutine(ActivateStunTrap());
        }
    }

    void UpdateTetherPosition()
    {
        lineRenderer.SetPosition(0, player1.transform.position);
        lineRenderer.SetPosition(1, player2.transform.position);
    }

    IEnumerator ActivateLaserWhip()
    {
        isLaserWhipActive = true;
        GameObject laserWhip = Instantiate(laserWhipPrefab, (player1.transform.position + player2.transform.position) / 2, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Destroy(laserWhip);
        isLaserWhipActive = false;
    }

    IEnumerator ActivateStunTrap()
    {
        isStunTrapActive = true;
        GameObject stunTrap = Instantiate(stunTrapPrefab, (player1.transform.position + player2.transform.position) / 2, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Destroy(stunTrap);
        isStunTrapActive = false;
    }
}
