using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QJB.Shared
{
    public class OrderJDVModel
    {
        public int orderId { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime? orderDate { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string projectCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string projectName { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 封签号
        /// </summary>
        public string sealNo { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 到站时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNo { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        public string driver { get; set; }
        /// <summary>
        /// 始发站
        /// </summary>
        public string departure { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        public string terminal { get; set; }
        /// <summary>
        /// 车类型
        /// </summary>
        public string carTypeCode { get; set; }
        /// <summary>
        /// 车类型
        /// </summary>
        public string carTypeName { get; set; }
        /// <summary>
        /// 拍数
        /// </summary>
        public int beats { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public int mileage { get; set; }
        /// <summary>
        /// 高速费
        /// </summary>
        public decimal highspeedCharge { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal cost { get; set; }
        /// <summary>
        /// 回扣
        /// </summary>
        public decimal rebate { get; set; }
        /// <summary>
        /// 结算余额
        /// </summary>
        public decimal freight { get; set; }
        /// <summary>
        /// 油卡余额
        /// </summary>
        public decimal oilCardBalance { get; set; }
        /// <summary>
        /// 公里数
        /// </summary>
        public decimal kilometers { get; set; }
        /// <summary>
        /// 油卡充值
        /// </summary>
        public decimal oilCardTopup { get; set; }
        /// <summary>
        /// 用油情况
        /// </summary>
        public decimal oilCardUse { get; set; }
        /// <summary>
        /// 修车费
        /// </summary>
        public decimal repairfee { get; set; }
        /// <summary>
        /// 罚款
        /// </summary>
        public decimal fine { get; set; }
        /// <summary>
        /// 速通卡
        /// </summary>
        public decimal suTongCard { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        public decimal paycash { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public bool? settleState { get; set; }
        public DateTime? createDate { get; set; }
    }
}
