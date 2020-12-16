using QJB.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Models
{
    [Table("YX_OrderJD")]
    public class OrderJDModel
    {
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime? OrderDate { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        public string ProjectName { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 封签号
        /// </summary>
        public string SealNo { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 到站时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 始发站
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// 车类型
        /// </summary>
        public string CarTypeCode { get; set; }
        /// <summary>
        /// 车类型
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        public string CarTypeName { get; set; }
        /// <summary>
        /// 拍数
        /// </summary>
        public int Beats { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public int Mileage { get; set; }
        /// <summary>
        /// 高速费
        /// </summary>
        public decimal HighspeedCharge { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 回扣
        /// </summary>
        public decimal Rebate { get; set; }
        /// <summary>
        /// 结算余额
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// 油卡余额
        /// </summary>
        public decimal OilCardBalance { get; set; }
        /// <summary>
        /// 公里数
        /// </summary>
        public decimal Kilometers { get; set; }
        /// <summary>
        /// 油卡充值
        /// </summary>
        public decimal OilCardTopup { get; set; }
        /// <summary>
        /// 用油情况
        /// </summary>
        public decimal OilCardUse { get; set; }
        /// <summary>
        /// 修车费
        /// </summary>
        public decimal Repairfee { get; set; }
        /// <summary>
        /// 罚款
        /// </summary>
        public decimal Fine { get; set; }
        /// <summary>
        /// 速通卡
        /// </summary>
        public decimal SuTongCard { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        public decimal Paycash { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public bool? SettleState { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
