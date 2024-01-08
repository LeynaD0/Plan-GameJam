using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] bool canShoot;
    [SerializeField] float shootTimeOutDelta;
    [SerializeField] StarterAssetsInputs _input;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        shootTimeOutDelta = 0.1f;
    }

    // Update is called once per frame
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
            shootTimeOutDelta = 0.1f; //tiempo para que solo gaste una bala al disparar


            // poner sonido disparar
            // disparar bala
            Instantiate(ammo, transform.position, transform.rotation);

            currentAmmo--; //resta las balas

            //Cuando la munición llega a 0 se llama a la función de recargar            
            if (currentAmmo <= 0)
            {
                //poner sonido sin balas
                Debug.Log("sonido no balas");
                Reload();
            }

            //Raycast
            Vector3 pos = Input.mousePosition;
            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (hitInfo.collider.tag.Equals("Enemy"))
                {
                    //quitar vida al enemigo
                }
            }

            
        }

        //tiempo para que solo gaste una bala al disparar
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
        Debug.Log("recargando");
        canShoot = false; //false para que no pueda disparar mientras recarga
        yield return new WaitForSeconds(3); //tiempo a esperar mientras recarga
        Debug.Log("regargada");
        currentAmmo = maxAmmo; //reincia la munición
        canShoot = true; //true para que pueda disparar
    }

}
