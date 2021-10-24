using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityAssetsServer.Model;

namespace UnityAssetsServer.Conrollers {
    [Route(@"api/v1/asset")]
    public class AssetsContoller : ControllerBase {
        private readonly IAssetStorage _assetStorage;

        private readonly ILogger<AssetsContoller> _logger; 

        public AssetsContoller(IAssetStorage assetStorage, ILogger<AssetsContoller> logger) {
            _assetStorage = assetStorage;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult SetAsset(string assetName) {
            var fileStream = _assetStorage.FindAsset(assetName);
            
            _logger.LogInformation($"Try to download: {assetName}");
            return File(fileStream, "application/octet-stream", assetName);
        }

        [HttpPost("file")]
        public async Task<IActionResult> PutFileAsync(string assetName, IFormFile file) {
            using var binaryReader = new BinaryReader(file.OpenReadStream());
            var data = binaryReader.ReadBytes((int)file.Length);
            await _assetStorage.SaveFile(assetName, data);
            return Ok();
        }

        [HttpGet("files")]
        public IActionResult ListFilse() => Ok(_assetStorage.ListFiles());

    }
}
