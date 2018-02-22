namespace Pif.Models
{
    public class AppConfig
    {
        #region Cloudinary

        public string CloudinaryBaseUrl => "https://res.cloudinary.com/";
        public string GeneralImage => "upload/q_auto/w_650,h_670/w_600,c_scale,x_0,y_0,a_0,l_watermark/";
        public string FreeImage => "upload/w_650,h_670/";
        public string DownloadImage => "upload/w_640,h_670/";
        public string ViewImageFree => "upload/";
        public string ViewImageNotFree => "upload/q_auto:best/w_400,g_south_east,y_20,l_watermark/w_400,g_south_west" +
                                          ",y_20,l_watermark/w_400,g_north_west,y_20,l_watermark/w_400,g_north_east,y_20" +
                                          ",l_watermark/w_400,g_east,y_20,l_watermark/w_400,g_west,y_20,l_watermark" +
                                          "/w_400,g_south,y_20,l_watermark/w_400,g_north,y_20,l_watermark/w_800" +
                                          ",c_scale,x_0,y_0,a_0,l_watermark/";
        public string ViewImageFreeModal => "upload/q_auto/w_550,h_570/";
        public string ViewImageNotFreeModal => "upload/q_auto/w_550,h_570/w_540,c_scale,x_0,y_0,a_0,l_watermark/";
        public string TableImage => "upload/q_auto/w_60,h_80/w_50,l_watermark/";
        public string LargeImage => "upload/w_1920,h_1280/";
        public string MeduiumImage => "upload/w_1280,h_853/";
        public string SmallImage => "upload/w_640,h_426/";
        public string A5Image => "upload/w_559,h_794/";
        public string A4Image => "upload/w_794,h_1123/";
        public string A3Image => "upload/w_1123,h_1587/";
        public string A2Image => "upload/w_1587,h_2245/";
        public string A1Image => "upload/w_2245,h_3571/";


        #endregion

        #region SSO
        //public string SSOBaseUrl => "http://localhost:53017/";
        public string SSOBaseUrl => "http://sso.camerack.com/";
        public string RegisterUsersUrl => SSOBaseUrl + "API/Register";
        public string LoginUrl => SSOBaseUrl + "API/Login";
        public string FetchUsersUrl => SSOBaseUrl + "API/AllUsers";
        public string ForgotPasswordLinkUrl => SSOBaseUrl + "API/ForgotPasswordResetLink";
        public string ResetPasswordUrl => SSOBaseUrl + "API/PasswordReset";
        public string ChangePasswordrl => SSOBaseUrl + "API/ChangePassword";
        public string EditProfileUrl => SSOBaseUrl + "API/UpdateProfile";
        public string ActivateAccountUrl => SSOBaseUrl + "API/ActivateAccount/";
        public string DeActivateAccount => SSOBaseUrl + "API/DeActivateAccount/";
        public string FetchUsersAccessKeys => SSOBaseUrl + "API/AllUsersAccessKeys";
        public string UpdatePasswordAccessKey => SSOBaseUrl + "API/UpdatePasswordAccessKey/";
        public string UpdateAccountActivationAccessKey => SSOBaseUrl + "API/UpdateAccountActivationAccessKey/";
        public long ClientId => 4;
        public string SavePushNotifications => SSOBaseUrl + "API/SavePushNotifications";
        public string UsersPushNotifications => SSOBaseUrl + "API/GetPushNotifications";
        public string UpdatePushNotifications => SSOBaseUrl + "API/UpdatePushNotifications";

        #endregion

        #region Photostudio API URL
        public string AppBaseUrl => "https://camerack.com/";
        public string PhotoStudioBaseUrl => "http://studio.camerack.com/";
        public string SecurePhotoStudioBaseUrl => "https://studio.camerack.com/";
        //public string PhotoStudioBaseUrl => "http://localhost:63274/";
        //public string SecurePhotoStudioBaseUrl => "http://localhost:63274/";
        public string FetchImagesUrl => PhotoStudioBaseUrl + "API/GetAllImages";
        public string FetchImageCategoryUrl => PhotoStudioBaseUrl + "API/GetAllImageCategories";
        public string FetchImageActionUrl => PhotoStudioBaseUrl + "API/GetAllImageActions";
        public string FetchImageTagUrl => PhotoStudioBaseUrl + "API/GetAllImageTags";
        public string FetchImageCommentsUrl => PhotoStudioBaseUrl + "API/GetAllImageComments";
        public string FetchPhotoCategoryUrl => PhotoStudioBaseUrl + "API/GetAllPhotographyCategories";
        public string FetchPhotoCategoryMappingUrl => PhotoStudioBaseUrl + "API/GetAllPhotographyCategoryMapping";
        public string SaveImageActionUrl => PhotoStudioBaseUrl + "API/SaveImageAction";
        public string SaveCommentUrl => PhotoStudioBaseUrl + "API/SaveComment";
        public string SaveImageReportUrl => PhotoStudioBaseUrl + "API/SaveReport";
        public string FetchCameraUrl => PhotoStudioBaseUrl + "API/GetAllImageCameras";
        public string FetchLocationUrl => PhotoStudioBaseUrl + "API/GetAllImageLocations";
        public string FetchSliders => PhotoStudioBaseUrl + "API/GetAllSliderImages";
        public string FetchAdvertismentsImages => PhotoStudioBaseUrl + "API/GetAllAdvertisments";
        public string FetchHeaderImages => PhotoStudioBaseUrl + "API/GetAllHeaderImages";
        public string UserProfilePicture => SecurePhotoStudioBaseUrl + "UploadedImage/ProfilePicture/";
        public string ImageCategoryPicture => SecurePhotoStudioBaseUrl + "UploadedImage/ImageCategory/";
        public string PhotoCategoryPicture => SecurePhotoStudioBaseUrl + "UploadedImage/PhotoCategory/";
        public string HeaderPicture => SecurePhotoStudioBaseUrl + "UploadedImage/Header/";
        public string AdvertPicture => SecurePhotoStudioBaseUrl + "UploadedImage/Advert/";
        public string SliderPicture => SecurePhotoStudioBaseUrl + "UploadedImage/Slider/";
        public string AboutUsPicture => SecurePhotoStudioBaseUrl + "UploadedImage/About/";
        public string UpdateAdCount => PhotoStudioBaseUrl + "API/UpdateAdCount/";
        public string GetTermsAndConditions => PhotoStudioBaseUrl + "API/GetAllTermsAndConditions";
        public string GetFaq => PhotoStudioBaseUrl + "API/GetFaq";
        public string GetPrivacyPolicy => PhotoStudioBaseUrl + "API/GetPrivacyPolicy"; 
        public string GetAboutUs => PhotoStudioBaseUrl + "API/GetAboutUs";


        #endregion

        #region Mailer

        public string EmailServer => "smtp.gmail.com";
        public string Email => "support@camerack.com";
        public string Password => "Brigada95";
        public int Port => 465;
        public string NewUserHtml => "wwwroot/EmailTemplates/NewUser.html";
        public string ForgotPasswordHtml => "wwwroot/EmailTemplates/ForgotPassword.html";
        public string CompetitionHtml => "wwwroot/EmailTemplates/Competition.html";
        public string ContactHtml => "wwwroot/EmailTemplates/Contact.html";

        #endregion

        #region SocialMediaLogin
        public string GoogleClientId => "64005477572-ej4cbjlh4v3bthvvl2flo1s4q095agv5.apps.googleusercontent.com";
        public string GoogleClientSecret => "A-yq8cwOYJnTM55y2irfQbcx";


        #endregion

        #region PaymentCharges

        public double PaystackPercentageCharge => 1.5;
        public double PaystackFixedCharge => 100;
        public string PaystackSecretKey => "sk_live_765f7faf4222757f471a414a6e01960e08b000b5";
        public string PaystackPublicKey => "pk_live_333e10b888b3d3bfc1c0b91b666c00a32cf39843";
        public string PaystackBaseUrl => "https://api.paystack.co/";
        public string PaystackValidateUrl => PaystackBaseUrl + "transaction/verify/";

        public double FlutterWavePercentageCharge => 1.4;
        public double FlutterWaveFixedCharge => 50;
        public string FlutterWaveSecretKey => "";
        public string FlutterWaveBaseUrl => "https://api.ravepay.co/flwv3-pug/getpaidx/";
        public string FlutterWaveValidateUrl => FlutterWaveBaseUrl + "api/verify";

        #endregion
        #region AppSetting

        public long PurchaseCharges => 5;
        public string SecurityCertificate => "wwwroot/Certificate/cert.crt";


        #endregion

        #region Cloudinary

        public string CloudinaryAccoutnName => "cloudmab";
        public string CloudinaryApiKey => "988581656515289";
        public string CloudinaryApiSecret => "Odh29Eet7Ajilw0O0kCflwtnj9E";

        #endregion
    }
}
