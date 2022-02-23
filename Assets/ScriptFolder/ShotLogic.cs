using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogic : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    private bool isPontClick = false;
    [SerializeField] private Rigidbody2D shotRigidboy2d;
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private GameObject haloObject;
    [SerializeField] private GameObject garbagePrefab;
    [SerializeField] private Transform garbagePrefabTransformPos;
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(isPontClick == true)
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(mousPos,shotRigidboy2d.position ) > maxDistance)
            {
                _rigidbody2d.position = shotRigidboy2d.position + (mousPos - shotRigidboy2d.position).normalized * maxDistance;
            }
            else
            {
                _rigidbody2d.position = mousPos;
            }
        }
    }
    private void OnMouseEnter()
    {
        haloObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        haloObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        isPontClick = true;
        _rigidbody2d.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isPontClick = false;
        _rigidbody2d.isKinematic = false;
        StartCoroutine(DropObject());
    }
    private IEnumerator DropObject()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if(garbagePrefab != null)
        {
            garbagePrefab.transform.position = garbagePrefabTransformPos.transform.position;
        }
    }
}
