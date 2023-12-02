using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupState : MonoBehaviour
{
    private UIUpdate uiUpdate;
    private CharacterSideScroller playerController;
    private Health health;

    public string currentPower = "";


    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<CharacterSideScroller>();
        health = GameObject.Find("Player").GetComponent<Health>();
        uiUpdate = GameObject.Find("UI Manager").GetComponent<UIUpdate>();

        PowerChange(currentPower);
    }


    public void PowerChange(string powerType){
        //Debug.Log("Received " + powerType);
        currentPower = powerType;

        switch(powerType){
            case "Invincibility":
                Invincibility(true);
                UpdatePowerupText(powerType);
            break;

            case "Double Jump":
                DoubleJump(true);
                UpdatePowerupText(powerType);
            break;

            case "Heal":
                Heal();
                UpdatePowerupText(powerType);
            break;

            default:
                //Debug.Log("Disabling powerup: "+powerType);
                currentPower = "";
                ClosePowerupText();
            break;
        }

        CleanseOtherPowers();
    }


    public void UpdatePowerupText(string text){
        //Debug.Log("Powering up");
        uiUpdate.Powerup(text);
    }


    public void ClosePowerupText(){
        uiUpdate.Powerdown();
    }


    private void CleanseOtherPowers(){
        if(currentPower != "Invincibility"){
            Invincibility(false);
        }
        if(currentPower != "Double Jump"){
            DoubleJump(false);
        }
        //no need to include Heal, it resets itself
    }


    private void DoubleJump(bool state){
        if(state){
            playerController.ChangeJumpCount(2);
        } else {
            playerController.ChangeJumpCount(1);
        }
    }


    private void Invincibility(bool state){
        health.Invincible(state);
    }


    private void Heal(){
        health.AddHealth(2);
        Invoke("HealReset", 3f);
    }


    private void HealReset(){
        //in case a new power is fetched between activation and reset
        if(currentPower == "Heal"){
            ClosePowerupText();
        }
    }
}
