using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.ViewModels
{
    public class OrderZWYSVModel
    {
        public int orderId { get; set; }
        public string orderNo { get; set; }
        public string cYBNo { get; set; }
        public DateTime? pickupDate { get; set; }
        public string franchiseStore { get; set; }
        public string storeStar { get; set; }
        public string recipient { get; set; }
        public string cityLevel { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string pieces { get; set; }
        public string signatory { get; set; }
        public DateTime? signDate { get; set; }
        public string remark { get; set; }
        public bool? settleState { get; set; }
        public string provinceCode { get; set; }
        public string provinceName { get; set; }
        public string cityCode { get; set; }
        public string cityName { get; set; }
        public string areaCode { get; set; }
        public string areaName { get; set; }
    }
}
