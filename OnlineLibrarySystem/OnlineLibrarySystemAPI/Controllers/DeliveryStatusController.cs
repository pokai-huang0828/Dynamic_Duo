using Microsoft.AspNetCore.Mvc;
using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Models.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OnlineLibrarySystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryStatusController : ControllerBase
    {
        [HttpGet]
        public string Get(int id, string deliveryStatus)
        {
            string returnStatus = "Invalid checkout id";

            CheckOutRepository checkOutRepository = new CheckOutRepository();
            var checkOutItem = checkOutRepository.GetByID(id);

            if(checkOutItem != null)
            {
                switch (deliveryStatus)
                {
                    case "AwaitingPickUp":
                        returnStatus = "InWarehouse";
                        checkOutItem.deliveryStatus = DeliveryStatus.InWarehouse;
                            break;
                    case "InWarehouse":
                        returnStatus = "InTransit";
                        checkOutItem.deliveryStatus = DeliveryStatus.InTransit;
                            break;
                    case "InTransit":
                        returnStatus = "OutForDelivery";
                        checkOutItem.deliveryStatus = DeliveryStatus.OutForDelivery;
                            break;
                    case "OutForDelivery":
                        returnStatus = "Delivered";
                        checkOutItem.deliveryStatus = DeliveryStatus.Delivered;
                            break;
                    case "Delivered":
                        returnStatus = "Delivered";
                        checkOutItem.deliveryStatus = DeliveryStatus.Delivered;
                            break;
                }

                try
                {
                    checkOutRepository.Update(checkOutItem);
                    Debug.WriteLine(checkOutRepository.GetByID(id).deliveryStatus);
                }
                catch(Exception ex)
                {
                    returnStatus = ex.Message;
                }

            }

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return returnStatus;
        }
    }
}
