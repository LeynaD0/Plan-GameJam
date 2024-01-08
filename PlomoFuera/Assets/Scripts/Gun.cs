using StarterAssets;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] bool canShoot = true;

    [SerializeField] StarterAssetsInputs _input;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
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
            if (_input.shoot && canShoot)
            {
                Debug.Log("shoot");

                canShoot = false;
                //Disparo
                //sonido disparar
                currentAmmo--;

                //Raycast
                Vector3 pos = Input.mousePosition;
                Ray rayo = Camera.main.ScreenPointToRay(pos);
                RaycastHit hitInfo;
                if (Physics.Raycast(rayo, out hitInfo))
                {
                    if (hitInfo.collider.tag.Equals("Enemy"))
                    {


                    }
                }
                canShoot = true;
            }    
        if(currentAmmo <= 0)
        {
            Reload();
        }
    }

    //Recargar
    private void Reload()
    {   
        StartCoroutine(WaitReload());        
    }

    IEnumerator WaitReload()
    {
        //sonido recargar
        canShoot = false;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(3);
        Debug.Log("Reloaded");
        currentAmmo = maxAmmo;
        canShoot = true;
    }

}
