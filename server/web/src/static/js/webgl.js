function loadWebGL(gameName) {
    let gameInstance = UnityLoader.instantiate(
        "game-container",
        "/static/webgl-build/" + gameName + "/Build/webgl.json",
        {
            onProgress: UnityProgress
        }
    );
}