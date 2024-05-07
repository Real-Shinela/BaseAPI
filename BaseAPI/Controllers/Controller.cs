using Microsoft.AspNetCore.Mvc;
using BaseAPI.Structure;
using BaseAPI.Excel;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly ExcelReader _excelService;
        private readonly string _excelFilePath = "D:\\test.xlsx"; // CHANGE THIS TO THE DESIRED EXCEL LIST!

        public Controller()
        {
            _excelService = new ExcelReader();
        }

        // Controllers/DataController.cs
        [HttpGet]
        public JsonResult Get()
        {
            List<ResponseStructure> structures = _excelService.ReadData(_excelFilePath);
            return new JsonResult(structures);
        }

    }
}
