using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttacks
{
	MELEE,
	SHOOT,
	DEFAULT
}
namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class EnemyAttack : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[Header("Info attacks")]
		[SerializeField] private int _meleeDamage;
		[SerializeField] private int _fireDamage;
		[Space(3)]
		[Header("Bullet GO")]
		[SerializeField] private Transform _proyectileInitPos;
		[SerializeField] private GameObject _proyectile;
		[SerializeField] private float _fireRate;
		[Space(3)]
		[Header("Control")]
		[SerializeField] private bool _inReach = false;
		[SerializeField] private bool _isAttacking = false;
		[SerializeField] private bool _canShoot = false;
		[SerializeField] private bool _canHit = false;
		[Space(3)]
		[Header("Times")]
		[SerializeField] private float _meleeTime = 3.0f;
		[SerializeField]private float nextTime = 0.0f;
		#endregion
		#region Public Fields
		public EnemyAttacks attackType;
		public int randomAttackType;
		public bool inReach { get { return _inReach; }set{ _inReach = value; } }
		public bool canShoot { get { return _canShoot; } set { _canShoot = value; } }
		public bool canHit { get { return _canHit; } set { _canHit = value; } }
		#endregion
		#region Lifecycle
		#endregion
		#region Public API
		#endregion
		#region Unity Methods
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			if (_isAttacking)
			{
				_meleeTime -= Time.deltaTime;
				if (_meleeTime <= 0.0f)
				{
					_isAttacking = false;
					_canHit = true;
					_meleeTime = 3.0f;
				}
			}

            if (!_canShoot)
            {
                nextTime += Time.deltaTime;

                if (nextTime >= _fireRate)
                {
                    _canShoot = true;
					nextTime = 0.0f;
                }
            }
        }

		// Awake is called when the script is
		// first loaded or when an object is
		// attached to is instantiated
		void Awake()
		{
			
		}
	    
		// FixedUpdate is called at fixed time intervals
		void FixedUpdate()
		{
			
		}
            
		// LateUpdate is called after all Update functions have been called
		#endregion
		#region Private Methods
		#endregion            
		#region Public Methods
		public void MeleeAttack()
		{
			if (_canHit && _inReach)
			{
				_isAttacking = true;
                Debug.Log("Ataque cuerpo a cuerpo");
                HealthManager.Instance.ModifyHealth(-_meleeDamage);
                _inReach = false;
				_canHit = false;
            }
		}
		public void ShootAttack()
		{
            Debug.Log("Ataque a distancia");
			GameObject clone = Instantiate(_proyectile, _proyectileInitPos.position, Quaternion.identity);
			_canShoot = false;
        }
		#endregion
	}
}