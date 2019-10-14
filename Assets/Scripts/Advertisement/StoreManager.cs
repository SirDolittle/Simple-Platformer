using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class StoreManager : MonoBehaviour, IStoreListener
{
    private static IStoreController ms_storeController;//This is where we will store the handle to our store controller. Unity will return this to us in the initialised section. 
    private static IExtensionProvider ms_extentionProvider;//This is where we will store the handle to our extension provider. Unity will return this to us in the initialised section. 
    /*
     * Add your products here. It is important to come up with a good naming convention for these
     * 
     */
    #region products you wanna have
    public string pound_one = "pound_one";
    public string pound_two = "pound_two";
    public string pound_twenty = "pound_twenty";
    public string pound_fourty = "pound_fourty";

    public string episode_one = "episode_one";
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //now we need to check whether we already initilised our store or not, if not, this means our store controller variable value must be null.
        if (ms_storeController == null)
        {
            initialiseIAP();
        }

    }
    #region Initialisation and Callback functions from IAP framework and stores
    #region initialisation of IAP
    private void initialiseIAP()
    {
        StandardPurchasingModule myPurchasingModule = StandardPurchasingModule.Instance();//Purchasing module to use in this store.
        myPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.DeveloperUser;//We use fake environment to test our game economy
        ConfigurationBuilder myCB = ConfigurationBuilder.Instance(myPurchasingModule);

        myCB.AddProduct(pound_one, ProductType.Consumable);
        myCB.AddProduct(pound_two, ProductType.Consumable);
        myCB.AddProduct(pound_twenty, ProductType.Consumable);
        //myCB.AddProduct(pound_twenty, ProductType.Consumable);
        myCB.AddProduct(episode_one, ProductType.NonConsumable);

        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, myCB);
    }
    public bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return ms_storeController != null && ms_extentionProvider != null;
    }

    public void OnInitialized(IStoreController _controller, IExtensionProvider _extensions)
    {
        ms_storeController = _controller;
        ms_extentionProvider = _extensions;
        //in order to test that our products are setup correctly, we can print them out here, using the StoreController.
        foreach (Product p in ms_storeController.products.all)
        {
            print(p.metadata.localizedTitle + " | "
                + p.metadata.localizedPriceString + " | "
                + p.metadata.localizedDescription);
        }
    }

    public void OnInitializeFailed(InitializationFailureReason _err)
    {
        print("error with initialising!");
        /*
         * Since this callback function returns the failure reason as an enum, 
         * go ahead and add some error handling here.
         * Use if statements or Switch to print something relevant depending on the failure reason. 
         * There are three possible scenarios here, you can find out about these by typing InitializationFailureReason.
         * or navigating to https://docs.unity3d.com/2018.2/Documentation/ScriptReference/Purchasing.InitializationFailureReason.html
         * 
         */
    }

    #endregion
    #region success or failure of a purchase
    /*
     * Some scenarios that may occure here are:
     * - Your game crashes after a purchase was initialised, in this case, Unity IAP will send you the message next time your app loads up. So remember this!
     * - Your user goes offline. They then get the purchase result next time they are connected. 
     */
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs _args)
    {
        if (string.Equals(_args.purchasedProduct.definition.id, pound_one, System.StringComparison.Ordinal))
        {
            print("ProcessingPurchase: PASS. Produce: " + _args.purchasedProduct.definition.id);
            DataManager.Instance.BuyGold(1);
            //do the rest here.
        }
        if (string.Equals(_args.purchasedProduct.definition.id, pound_two, System.StringComparison.Ordinal))
        {
            print("ProcessingPurchase: PASS. Produce: " + _args.purchasedProduct.definition.id);
            DataManager.Instance.BuyGold(2);
            //do the rest here.
        }
        if (string.Equals(_args.purchasedProduct.definition.id, pound_twenty, System.StringComparison.Ordinal))
        {
            print("ProcessingPurchase: PASS. Produce: " + _args.purchasedProduct.definition.id);
            DataManager.Instance.BuyGold(20);
            //do the rest here.
        }
        if (string.Equals(_args.purchasedProduct.definition.id, pound_fourty, System.StringComparison.Ordinal))
        {
            print("ProcessingPurchase: PASS. Produce: " + _args.purchasedProduct.definition.id);
            DataManager.Instance.BuyGold(40);
            //do the rest here.
        }
        if (string.Equals(_args.purchasedProduct.definition.id, episode_one, System.StringComparison.Ordinal))
        {
            print("ProcessingPurchase: PASS. Produce: " + _args.purchasedProduct.definition.id);
            DataManager.Instance.BuyEpisodeOne();
            //do the rest here.
        }
        return PurchaseProcessingResult.Complete;
    }

    public string GetProductPriceFromStore(string _id)
    {
        if (IsInitialized())
        {
            return ms_storeController.products.WithID(_id).metadata.localizedPriceString;
        }
        return "";

    }
    /*Add your code here for cases of failure and test it using the fake store interface*/
    public void OnPurchaseFailed(Product _pr, PurchaseFailureReason _err)
    {

    }
    #endregion
    #endregion

    #region purchasing/buying functions
    public void BuyPoundOne()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(pound_one);
    }
    public void BuyPoundTwo()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(pound_two);
    }
    public void BuyPoundTwenty()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(pound_twenty);
    }
    public void BuyPoundFourty()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(pound_fourty);
    }
    public void BuyEpisodeOne()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(episode_one);
    }


    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            /*Now we know storeController and extension provider are both
             * initialised, we want to get the product from our store to initiate its purchase. We use the product id to find it in our store.*/
            Product product = ms_storeController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.LogFormat("Purchasing product asychronously: {0}", product.definition.id);
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                //OnPurchaseFailed and ProcessPurchase are both callback functions, which means once the purchase is initiated, the relevant store will 
                //call one of these two functions with message and details of the transaction. 
                ms_storeController.InitiatePurchase(product);//This is where magic happens!
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }
    #region Apple only - Restore function
    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    // 
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            IAppleExtensions apple = ms_extentionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });

        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
        /*TODO*/
    }
    #endregion
    #endregion

    #region Validating reciepts from purchases.
    private bool ValidateReceipt(Product _product)
    {
        bool result = false;
        //TODO: Add validating code here. Not initialised yet as we can't test them without real store.

        return result;
    }

    #endregion
    // Update is called once per frame
    void Update()
    {

    }
}