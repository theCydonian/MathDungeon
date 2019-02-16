let gameInstance = UnityLoader.instantiate(
    "game-container",
    "/static/webgl-build/Build/webgl.json",
    {
        onProgress: UnityProgress
    }
);
