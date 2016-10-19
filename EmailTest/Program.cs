using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dm.Model.V20151123;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //            EmailServiceClient _client = new EmailServiceClient("cn-hangzhou", "3a2E7mazpyKjPLCF", "9JjiyjVdZEp7lrxs4Ij6KmZtUxNkp1");

            //            string _mailBody = @"<table border='0' cellpadding='0' cellspacing='0' width='750' style='margin: 0 auto;'>
            //        <tbody style='font-family:微软雅黑;'>
            //            <tr>
            //                <td>
            //                    <div style='background: #f7f7f7; height:70px;line-height:70px;font-size:20px; padding:0;margin:0;'>
            //                        <a href='http://www.txooo.com/' style='text-decoration:none;font-size:30px;color:#333; padding-left:20px;font-family:黑体'></a>
            //                        <span style='color: #7b7b7b;float:right;margin-right:20px;'>让轻松简单</span>
            //                    </div>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>
            //                    <div style='background: #cb2b18; height: 286px; font-size: 20px; padding: 0; margin: 0;'>
            //                        <p style='margin: 0; text-align: center; padding: 26px 0 0; font-size: 16px; color: #fde4ac;line-height:22px;'>   
            //                                  2016年，为支持全民创业，<br />
            //                            联合众多创业品牌，共同推出
            //                        </p>
            //                        <p style='margin: 0; text-align: center; padding: 0; font-size: 58px; color: #ffed27; line-height: 70px; '>创业券</p>
            //                        <p style='margin: 0; text-align: center; padding: 6px; font-size: 18px; color: #fde4ac;line-height:22px;'>
            //                            您的精彩，与众不同，从这里开始！
            //                        </p>
            //                        <div style='width: 360px; height: 70px; line-height: 70px; border: 2px solid #ffed27; margin: 10px auto; padding: 0; background: #cf3a28'>
            //                            <span style='float:left;background:#ffed27;width:50%;font-weight:bold;color:#cb2b18;font-size:38px; height:70px;overflow:hidden; text-align:center;'>1000<em style='font-style:normal;font-size:20px;font-weight:normal;display:inline-block;'>元</em></span>
            //                            <span style='float:left;width:50%;font-weight:bold;color:#ffed27;font-size:38px; height:70px;overflow:hidden; text-align:center;'>抵3000<em style='font-style:normal;font-size:20px;font-weight:normal;display:inline-block;'>元</em></span>
            //                        </div>
            //                    </div>
            //                </td>
            //            </tr>
            //        </tbody>
            //</table>
            //";

            //            var _msgInfo = new { msg_id = 1, subject = "亲，恭喜您成为创业券的首批体验用户！", content = _mailBody };
            //            //_client.Send("server@edm.txooo.com", "天下商机", "381605825@qq.com", _msgInfo, "txooo");


            //            var _userList = new List<dynamic>();
            //            _userList.Add(new { email_id = 100000000, email = "381605825@qq.com" });
            //            //_userList.Add(new { email_id = 3, email = "zdl8061@163.com" });

            //            _client.SendOneByOne("server@edm.txooo.com", "天下商机", _userList, _msgInfo, "txooo");

            string s = "adsf";

            Console.Write(s);

            Console.ReadKey();
        }

   
     
    }
}
