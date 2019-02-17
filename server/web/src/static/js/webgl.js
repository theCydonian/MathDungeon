function loadWebGL(gameName) {
    let gameInstance = UnityLoader.instantiate(
        "game-container",
        "/static/webgl-build/" + gameName + "/Build/webgl-build-" + gameName + ".json",
        {
            onProgress: UnityProgress
        }
    );
}