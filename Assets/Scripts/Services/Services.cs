public static class ServicesLocator {

    public static void Initialization() {
        CameraManager.Initialize();
        //Music.Initialize();
    }
    public static CameraManager CameraManager;
    public static GameManager GameManager;
    public static SceneChangeManager SceneChanger;
    public static MusicManager Music;
    public static ItemLibrary_2 ItemLibrary;
    public static DialogueManager DialogueManager;
    public static PlayerInteractor PlayerInteractor;
    public static LightManager LightManager;

}