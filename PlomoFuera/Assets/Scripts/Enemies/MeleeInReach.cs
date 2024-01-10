using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VictorRivero{

	/// <summary>
	/// 
	/// </summary>

	public class MeleeInReach : MonoBehaviour
	{
		#region Static Fields
		#endregion
		#region Const Field
		#endregion
		#region Param Fields
		#endregion
		#region Private Fields
		[SerializeField] private EnemyAttack _enemyAttack;
		#endregion
		#region Public Fields
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
		private void OnTriggerEnter(Collider other)
		{
            if (other.CompareTag("Player"))
            {
				if (_enemyAttack.canHit)
				{
					_enemyAttack.inReach = true;
				}
            }
        }
		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
                _enemyAttack.inReach = false;
            }
		}
		#endregion
		#region Public Methods
		#endregion
	}
}