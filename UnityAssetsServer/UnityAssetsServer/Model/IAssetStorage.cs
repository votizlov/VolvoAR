using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UnityAssetsServer.Model {
    public interface IAssetStorage {
        FileStream FindAsset(string assetName);
        IEnumerable<string> ListFiles();
        Task SaveFile(string assetName, byte[] data);

    }
}
