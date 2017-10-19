using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator anim;
    private AudioSource _AudioSource;

    public float range = 100f; //maximum distance for the bullets
    public int bulletsPerMag = 30; //bullets per magazine
    public int bulletsLeft = 200; //total bullets
    public int currentBullets; //current bullets in magazine

    public enum shootMode { Auto, Semi }
    public shootMode shootingMode; //2 modes auto and semi

    public Transform shootPoint; //the point from which the bullet leaves the muzzle
    public GameObject hitParticles; //impact of the bullet
    public GameObject bulletImpact; //impact of the bullet

    public ParticleSystem muzzleFlash; //flash when the shell leaves the gun
    public AudioClip shootSound; //sound of the shot

    public float fireRate = 0.1f; //delay between shots

    float fireTimer; //time counter for delay
    public float damage = 30f; //damage the weapon does

    private bool isReloading; //if you are reloading
    private bool isAiming; //if you are aiming
    private bool shootInput; //if is auto or semi

    private Vector3 originalPosition; //original view position of the weapon
    public Vector3 aimPosition; //position of the weapon while aiming
    public float adsSpeed = 8f; //aim down sights speed
    public float crSpeed = 1; //crouch speed

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();

        currentBullets = bulletsPerMag;
        originalPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        switch (shootingMode)
        {
            case shootMode.Auto:
                shootInput = Input.GetButton("Fire1");
                break;

            case shootMode.Semi:
                shootInput = Input.GetButtonDown("Fire1");
                break;
        }
               
		if (shootInput)
        {
            if (currentBullets > 0)
                Fire();
            else if (bulletsLeft > 0)
                Reload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if ((currentBullets < bulletsPerMag) && (bulletsLeft > 0))
                Reload();
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        AimDownSights();
        autoToSemi();
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        anim.SetBool("Aim", isAiming);

        isReloading = info.IsName("Reload");
    }

    private void autoToSemi()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (fireRate == 0.1f)
                fireRate = 0.5f;
            else fireRate = 0.1f;
        }
    }

    private void AimDownSights()
    {
        if (Input.GetButton("Fire2") && !isReloading)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * adsSpeed);
            isAiming = true;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * adsSpeed);
            isAiming = false;
        }
    }

    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <= 0 || isReloading) return;

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            Destroy(hitParticleEffect, 1f); //despawn the hit particle effect after 1 second

            if (hit.transform.GetComponent<HealthZombie>())
            {
                if (hit.collider is BoxCollider)
                    hit.transform.GetComponent<HealthZombie>().ApplyHeadshotDamage();
                else hit.transform.GetComponent<HealthZombie>().ApplyDamage(damage);
            }
        }

        anim.CrossFadeInFixedTime("Fire", 0.1f);
        muzzleFlash.Play(); //show the flash
        PlayShootSound(); //call function

        currentBullets--; //bullets -1
        fireTimer = 0.0f; //reset fire time
    }

    private void Reload()
    {
        if (bulletsLeft <= 0) return;

        int bulletsToLoad = bulletsPerMag - currentBullets;
        //                      IF                             DO           ELSE  DO
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct; //bullets left - the bullets shot
        currentBullets += bulletsToDeduct; //current bullets in mag + bullets shot from previous mag
    }

    private void PlayShootSound()
    {
        _AudioSource.PlayOneShot(shootSound); //play the shot sound 
    }

    public void addBullets()
    {
        if (bulletsLeft >= 200)
            return;
        else bulletsLeft += 10;

        if (bulletsLeft > 200)
            bulletsLeft = 200;
    }
}
