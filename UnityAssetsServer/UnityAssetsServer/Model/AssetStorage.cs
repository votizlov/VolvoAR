using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UnityAssetsServer.Model {
    public class AssetStorage : IAssetStorage {
        private readonly string _assetsDirectory;

        public AssetStorage(string assetsDirectory) {
            if (string.IsNullOrWhiteSpace(assetsDirectory)) {
                throw new ArgumentException($"'{nameof(assetsDirectory)}' cannot be null or whitespace.", nameof(assetsDirectory));
            }
            _assetsDirectory = assetsDirectory;
        }

        public FileStream FindAsset(string assetName) {
            var path = Path.Combine(_assetsDirectory, assetName);
            return File.OpenRead(path);
        }

        public async Task SaveFile(string assetName, byte[] data) {
            await File.WriteAllBytesAsync(Path.Combine(_assetsDirectory, assetName), data);
        }

        public IEnumerable<string> ListFiles() => Directory.EnumerateFiles(_assetsDirectory).Select(x => Path.GetFileName(x));
    }
}
