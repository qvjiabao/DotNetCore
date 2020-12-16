using Jabo.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Models
{
    [Table("YX_OrderZWYS")]
    public class OrderZWYSModel
    {
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 仓易宝单号
        /// </summary>
        public string CYBNo { get; set; }
        /// <summary>
        /// 提货日期
        /// </summary>
        public DateTime? PickupDate { get; set; }
        /// <summary>
        /// 专营店号
        /// </summary>
        public string FranchiseStore { get; set; }
        /// <summary>
        /// 门店星级
        /// </summary>
        public string StoreStar { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// 城市等级
        /// </summary>
        public string CityLevel { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public int? Pieces { get; set; }
        /// <summary>
        /// 签收人
        /// </summary>
        public string Signatory { get; set; }
        /// <summary>
        /// 签收日期
        /// </summary>
        public DateTime? SignDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public bool? SettleState { get; set; }
        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区编码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 区名称
        /// </summary>
        public string AreaName { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDisplayName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyUserName { get; set; }
        public string ModifyDisplayName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
