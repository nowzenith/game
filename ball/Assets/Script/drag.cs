using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class drag : MonoBehaviour

{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public buildline tl;

    private float slowmo = 0.1f;
    private float normtime = 1.0f;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<buildline>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            Time.timeScale = slowmo;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            Time.timeScale = normtime;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "lava")
        {
            Destroy(gameObject);
            AdsManager.Instance.ShowVideoAd();
        }
    }
}
