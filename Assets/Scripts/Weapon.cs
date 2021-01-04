using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject hitEffect;

    private void Start()
    {
        muzzleFlash.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } else if(Input.GetButtonUp("Fire1"))
        {
            muzzleFlash.SetActive(false);
        }

    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        // StartCoroutine(Rotate(0.1f));
        muzzleFlash.SetActive(true);
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = muzzleFlash.transform.eulerAngles.z;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            muzzleFlash.transform.eulerAngles = new Vector3(muzzleFlash.transform.eulerAngles.x, muzzleFlash.transform.eulerAngles.y,
            zRotation);
            yield return null;
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
