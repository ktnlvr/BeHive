using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PurchaseManager : MonoBehaviour
{
    public int ItemSelected;
    public LayerMask floorLayer;
    public LayerMask obstacleLayer;
    private PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();   
    }

    public void Summon(byte id)
    {
        switch(id)
        {
            case 1:
                SummonHive();
                break;
            case 0:
            default:
                throw new MissingReferenceException($"Whoopsy, you tried to summon smth with a wrong id: {id}");
        }
    }

    private void SummonHive()
    {
        Vector3 summonPosition = playerController.transform.position + playerController.camera.transform.forward * Rules.PurchaseDistance + Vector3.up * Rules.PurchaseHeight;
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        if (ItemSelected != 0 && Application.isPlaying)
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(playerController.camera.transform.position, playerController.camera.transform.forward, out hit, Rules.BuildDistance, floorLayer))
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(hit.point, 0.03f);
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(playerController.camera.transform.position, playerController.camera.transform.forward * Rules.BuildDistance);
                if (Physics.OverlapBox((Options.SnapToGrid ? Vector3Int.RoundToInt(hit.point) : hit.point) + Vector3.up / 2f, Vector3.one * 0.45f, Quaternion.identity, obstacleLayer | floorLayer).Length >= 1)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.gray;
                Gizmos.DrawWireCube((Options.SnapToGrid ? Vector3Int.RoundToInt(hit.point) : hit.point) + Vector3.up / 2f, Vector3.one); 
                
            }
        }
    }
}