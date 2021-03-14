public static class ServicesLocator {

    public static void Initialization() {
        CameraManager.Initialize();
        Music.Initialize();
    }
    public static CameraManager CameraManager;
    public static GameManager GameManager;
    public static SceneChangeManager SceneChanger;
    public static MusicManager Music;
    public static ItemLibrary ItemLibrary;
    //public static DialogueManager DialogueManager;

}