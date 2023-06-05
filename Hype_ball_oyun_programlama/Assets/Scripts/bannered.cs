using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class bannered : MonoBehaviour
{
    // For the purpose of this example, these buttons are for functionality testing:
    [SerializeField] Button _loadBannerButton;
    [SerializeField] Button _showBannerButton;
    [SerializeField] Button _hideBannerButton;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms.

    void Start()
    {

        if (PlayerPrefs.HasKey("NoAds") == false)
        {
            PlayerPrefs.SetInt("NoAds", 0);
        } 

        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif



        // Set the banner position:
        Advertisement.Banner.SetPosition(_bannerPosition);

        LoadBanner();
    }

   
    public void LoadBanner()
    {
   
        if (PlayerPrefs.HasKey("NoAds") && PlayerPrefs.GetInt("NoAds") == 0)
        {
           //Set up options to notify the SDK of load events:
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };

            // Load the Ad Unit with banner content:
            Advertisement.Banner.Load(_adUnitId, options);
        }

        else
        {
            return;
        }
        
    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

        ShowBannerAd();

        // Configure the Show Banner button to call the ShowBannerAd() method when clicked:
        // _showBannerButton.onClick.AddListener(ShowBannerAd);
        // Configure the Hide Banner button to call the HideBannerAd() method when clicked:
        //  _hideBannerButton.onClick.AddListener(HideBannerAd);

        // Enable both buttons:
        // _showBannerButton.interactable = true;
        // _hideBannerButton.interactable = true;
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // Clean up the listeners:
        _loadBannerButton.onClick.RemoveAllListeners();
        _showBannerButton.onClick.RemoveAllListeners();
        _hideBannerButton.onClick.RemoveAllListeners();
    }
}