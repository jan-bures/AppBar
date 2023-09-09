#if UNITY_EDITOR

namespace AppBarLib
{
    public enum GameState : byte
    {
        Invalid = 0,
        WarmUpLoading = 1,
        MainMenu = 2,
        KerbalSpaceCenter = 3,
        VehicleAssemblyBuilder = 10,
        BaseAssemblyEditor = 11,
        FlightView = 20,
        ColonyView = 21,
        Map3DView = 22,
        PhotoMode = 30,
        MetricsMode = 31,
        PlanetViewer = 32,
        Loading = 33,
        TrainingCenter = 40,
        MissionControl = 41,
        TrackingStation = 42,
        ResearchAndDevelopment = 43,
        Launchpad = 44,
        Runway = 45,
        Flag = 46
    }
}

#endif