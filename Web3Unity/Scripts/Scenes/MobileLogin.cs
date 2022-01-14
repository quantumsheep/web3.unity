using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLogin : MonoBehaviour
{
    async void Start()
    {
        // get current timestamp
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();
        // sign message
        string signature = await Web3Mobile.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
        // validate account
        if (account.Length == 42) {
            // save account
            PlayerPrefs.SetString("Account", account);
            print("Account: " + account);
            // load next scene
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            print("NEXT SENE");
        }
    }
}
