using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralFunctionsHelper {

    /// <summary>
    /// Check if layer is in layermask
    /// </summary>
    /// <param name="layer">Layer to check</param>
    /// <param name="layerMask">Layer mask to check against</param>
    /// <returns></returns>
    public static bool CheckLayerCollision(int layer, LayerMask layerMask) {

        return layerMask == (layerMask | (1 << layer));
    }
}
