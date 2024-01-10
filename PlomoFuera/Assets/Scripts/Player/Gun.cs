using StarterAssets;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Ammo")]
    [SerializeField] GameObject ammo;
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] bool canShoot;
    [SerializeField] float shootTimeOutDelta; //tiempo para que solo se dispare una bala
    [SerializeField] GameObject targetRotation; 
    [SerializeField] StarterAssetsInputs _input;
    
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip reloadAudio;
    [SerializeField] AudioClip noBulletsAudio;

    void Start()
    {
        currentAmmo = maxAmmo;
        shootTimeOutDelta = 0.1f; //tiempo para que solo se dispare una bala
    }

    void Update()
    {
        Shoot();

        if (_input.reload)
        {
            Reload();
        }            
    }

    //Disparar
    private void Shoot()
    {        
        if (_input.shoot && canShoot && shootTimeOutDelta <= 0.0f)
        {                
            shootTimeOutDelta = 0.1f; //tiempo para que solo se dispare una bala            

            Instantiate(ammo, transform.position, targetRotation.transform.rotation); //dispara una bala 

            currentAmmo--; //resta las balas

            //Cuando la munición llega a 0 se llama a la función de recargar            
            if (currentAmmo <= 0)
            {
                //sonido sin balas
                audioSource.clip = noBulletsAudio;
                audioSource.Play();

                Reload();
            }
        }

        //tiempo para que solo se dispare una bala
        if (shootTimeOutDelta >= 0.0f)
        {
            shootTimeOutDelta -= Time.deltaTime;
        }        
    }

    //Recargar
    private void Reload()
    {
        StartCoroutine(WaitReload());               
    }

    IEnumerator WaitReload()
    {
        //poner sonido de recarga
        audioSource.clip = reloadAudio;
        audioSource.Play();
        canShoot = false; //false para que no pueda disparar mientras recarga
        yield return new WaitForSeconds(3); //tiempo a esperar mientras recarga
        currentAmmo = maxAmmo; //reincia la munición
        canShoot = true; //true para que pueda disparar
    }

}
