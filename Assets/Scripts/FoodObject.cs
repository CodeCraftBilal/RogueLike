using UnityEngine;

public class FoodObject : CellObject
{
    public int amountGranted = 5;
    public override void PlayerEntered()
    {
        Debug.Log("amountGranted " + amountGranted);
        Destroy(gameObject);
        GameManager.Instance.ChangeFood(amountGranted);
        //increase food
        Debug.Log("Food increased");
    }
}