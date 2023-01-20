using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    PlayerManager player;
    float clampXValue=8f;
    float clampZValue=10f;
    public PlayerMovement(PlayerManager playerManager)
    {
        player = playerManager;
    }

    public void PlayerMove(float moveSpeed)
    {
        if (Input.touchCount>0)
        {
            float posXValue = Input.GetTouch(0).deltaPosition.x * Time.deltaTime * moveSpeed;
            float posZValue = Input.GetTouch(0).deltaPosition.y * Time.deltaTime * moveSpeed;
            player.transform.position += new Vector3(posXValue, 0, posZValue);

            PlayerClampPosition(clampXValue,clampZValue);

            PlayerRotating(posXValue,posZValue);

        }

    }

    private void PlayerClampPosition(float clampXValue,float clampZValue)
    {
        var clampXPosition = Mathf.Clamp(player.transform.position.x, -clampXValue, clampXValue);
        var clampZPosition = Mathf.Clamp(player.transform.position.z, -clampZValue, clampZValue);

        player.transform.position = new Vector3(clampXPosition, player.transform.position.y, clampZPosition);
    }

    private void PlayerRotating(float posX,float posZ)
    {
        Vector3 direction = Vector3.forward * posZ + Vector3.right * posX;
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction), 15 * Time.deltaTime);
    }
}