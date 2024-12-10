using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float blinkDistance = 5f;
    public float tetherRange = 10f;
    public GameObject otherPlayer;
    public GameObject tether;
    public GameObject shieldPrefab;
    public GameObject electrocuteEffectPrefab;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool isBlinking = false;
    private bool isShieldActive = false;
    private bool isElectrocuting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && !isBlinking)
        {
            StartCoroutine(Blink());
        }

        if (Vector2.Distance(transform.position, otherPlayer.transform.position) < 1f && !isShieldActive)
        {
            StartCoroutine(ActivateShield());
        }

        if (Vector2.Distance(transform.position, otherPlayer.transform.position) > tetherRange && !isElectrocuting)
        {
            StartCoroutine(Electrocute());
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    IEnumerator Blink()
    {
        isBlinking = true;
        Vector2 blinkPosition = rb.position + moveInput.normalized * blinkDistance;
        rb.MovePosition(blinkPosition);
        otherPlayer.GetComponent<PlayerController>().BlinkToPosition(blinkPosition);
        yield return new WaitForSeconds(0.5f);
        isBlinking = false;
    }

    public void BlinkToPosition(Vector2 position)
    {
        rb.MovePosition(position);
    }

    IEnumerator ActivateShield()
    {
        isShieldActive = true;
        GameObject shield = Instantiate(shieldPrefab, (transform.position + otherPlayer.transform.position) / 2, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(shield);
        isShieldActive = false;
    }

    IEnumerator Electrocute()
    {
        isElectrocuting = true;
        GameObject electrocuteEffect = Instantiate(electrocuteEffectPrefab, (transform.position + otherPlayer.transform.position) / 2, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(electrocuteEffect);
        isElectrocuting = false;
    }
}
