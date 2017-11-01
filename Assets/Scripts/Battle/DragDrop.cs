using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

    public GameObject battleManager;

	private Vector3 offset;
	private AudioSource audio;
    private BattleManager battleTask;

	void Start()
	{
		audio = GetComponent<AudioSource>();
        battleTask = battleManager.GetComponent<BattleManager>();
	}

	void OnMouseDown()
	{
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint
		(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
	}

	void OnMouseDrag()
	{
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
	}

	void OnMouseUp()
	{
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero, 1);

 		foreach(RaycastHit2D hit in hits) 
		 {
			 if (hit.collider.name == "InApp Store")
			 {
                battleTask.PurchaseWinButton();
                Destroy(gameObject);
			 }
             else if (hit.collider.name == "Toasto")
            {
                battleTask.PurchaseToastoUpgrade();
                Destroy(gameObject);
            }
         }
	}
}
