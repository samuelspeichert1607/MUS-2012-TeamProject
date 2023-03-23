using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageComponent : MonoBehaviour {

    public GameObject hitFX;
	void DealDamage() {
        transform.parent.GetComponent<DemoControllerAnimal>().DealDamage(this);
	}
	

}
