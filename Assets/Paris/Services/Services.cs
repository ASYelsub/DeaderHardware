public static class ServicesLocator {

    public static void Initialization() {
        CameraManager.Initialize();
    }

    public static CameraManager CameraManager;
    public static GameManager GameManager;

}