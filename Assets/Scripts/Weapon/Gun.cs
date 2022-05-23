using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Text bulletText;

    [Header("Audio")]
    [SerializeField] private AudioClip clipGunFire;
    [SerializeField] private AudioClip clipReload;
    [SerializeField] private AudioSource audioplayer;
    [Header("Particles")]
    [SerializeField] private ParticleSystem ARSparks;

    private float timeSinceLastShot;

    private void OnDisable()
    {
        gunData.reloading = false;
        gunData.currentAmmo = gunData.magSize;
    }

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!gunData.reloading)
            StartCoroutine(Reload());
    }

    private bool CanShoot()
    {
        return !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    }


    private IEnumerator Reload()
    {
        audioplayer.PlayOneShot(clipReload);
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;
        UpdateBulletUI();

        gunData.reloading = false;
    }

    private void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    if (hitInfo.transform.TryGetComponent(out Zombie zombie))
                    {
                        zombie.TakeDamage(gunData.damage);
                    }
                }

                ARSparks.Play();
                audioplayer.PlayOneShot(clipGunFire);
                gunData.currentAmmo--;
                UpdateBulletUI();
                timeSinceLastShot = 0;
            }
        }
    }

    void UpdateBulletUI()
    {
        bulletText.text = gunData.currentAmmo.ToString()+"/"+gunData.magSize.ToString();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(bulletSpawnPoint.position, bulletSpawnPoint.forward * gunData.maxDistance);
    }

}
