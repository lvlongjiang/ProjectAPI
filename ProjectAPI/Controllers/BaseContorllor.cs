using BPMAPI.OtherApi;
using bpmdemoapi.models;
using Microsoft.Extensions.Configuration;
using Model;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BPMModels = bpmdemoapi.models.BPMModels;

namespace ProjectAPI.Controllers
{
    public class BaseController
    {
        private IConfiguration configuration;
        public BaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        /// 获取table
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static DataSet GetDataSet(Object data)
        {
            Type type = data.GetType();
            DataSet formDataSet = new DataSet("FormData");

            DataTable table = new DataTable(type.Name);
            string IsNotField = "Action,BPMUser,BPMUserPass,FullName,ProcessName";
            foreach (var property in type.GetProperties())
            {
                if (!IsNotField.Contains(property.Name))
                    table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
            }
            DataRow add_row = table.NewRow();
            foreach (var property in type.GetProperties())
            {
                if (!IsNotField.Contains(property.Name))
                    add_row[property.Name] = property.GetValue(data);
            }
            table.Rows.Add(add_row);
            formDataSet.Tables.Add(table);
            return formDataSet;
        }
        public Task<int> StartProccess<T>(T leave) where T : BaseModels, new()
        {
            string formDataSet = ConvertXML.ConvertDataSetToXML(GetDataSet(leave));
            BPMModels models = new BPMModels(configuration)
            {
                Action = leave.Action,

                BPMUser = leave.BPMUser,
                BPMUserPass = leave.BPMUserPass,
                FormDataSet = formDataSet,
                FullName = leave.FullName,
                ProcessName = leave.ProcessName
            };
            return MyClientApi.OptClientApi(models.BpmServerUrl, models);
        }
    }
}
