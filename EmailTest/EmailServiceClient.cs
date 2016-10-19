using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dm.Model.V20151123;
/*----------------------------------------------------------------
 *  Copyright (C) 2015 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：EmailService
 *  所属项目：
 *  创建用户：张德良
 *  创建时间：2016/5/24 星期二 下午 12:48:22
 *  
 *  功能描述：
 *          1、
 *          2、 
 * 
 *  修改标识：  
 *  修改描述：
 *  待 完 善：
 *          1、 
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailTest
{
    public class EmailServiceClient
    {
        string m_regionId;
        string m_accessKeyId;
        string m_secret;
        private EmailServiceClient() { }
        public EmailServiceClient(string regionId, string accessKeyId, string secret)
        {
            this.m_regionId = regionId;
            this.m_accessKeyId = accessKeyId;
            this.m_secret = secret;
        }

        /// <summary>
        /// 群发（toAddress逗号分隔）
        /// </summary>
        /// <param name="fromEmail"></param>
        /// <param name="fromAlias"></param>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="consoleTag"></param>
        /// <returns></returns>
        public void Send(string fromEmail, string fromAlias, string toAddress, dynamic mailContent, string consoleTag)
        {
            Thread _thread = new Thread(new ParameterizedThreadStart(o =>
            {
                IClientProfile profile = DefaultProfile.GetProfile(m_regionId, m_accessKeyId, m_secret);
                IAcsClient client = new DefaultAcsClient(profile);
                SingleSendMailRequest request = new SingleSendMailRequest();
                try
                {
                    request.AccountName = fromEmail;
                    request.FromAlias = fromAlias;
                    request.AddressType = 1;
                    request.TagName = consoleTag;
                    request.ReplyToAddress = true;
                    request.ToAddress = toAddress;
                    request.Subject = mailContent.subject;
                    request.HtmlBody = string.Format(mailContent.content, "", "");
                    SingleSendMailResponse httpResponse = client.GetAcsResponse(request);

                    var _reqId = httpResponse.RequestId;

                    var _msgId = mailContent.msg_id;

                    //入库状态
                }
                catch (ServerException e)
                {
                    //Console.WriteLine("服务器异常:" + e.Message);
                    //记录日志
                }
                catch (ClientException e)
                {
                    //Console.WriteLine("客户端异常:" + e.Message);
                    //记录日志
                }
            }));

            _thread.Start(null);
        }

        /// <summary>
        /// 精准发送（toAddress逗号分隔）一封一封发每日2000封上限
        /// </summary>
        /// <param name="fromEmail"></param>
        /// <param name="fromAlias"></param>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="consoleTag"></param>
        /// <returns></returns>
        public void SendOneByOne(string fromEmail, string fromAlias, List<dynamic> recieveUsers, dynamic mailContent, string consoleTag)
        {
            Thread _thread = new Thread(new ParameterizedThreadStart(o =>
            {
                IClientProfile profile = DefaultProfile.GetProfile(m_regionId, m_accessKeyId, m_secret);
                IAcsClient client = new DefaultAcsClient(profile);

                foreach (dynamic _user in recieveUsers)
                {
                    SingleSendMailRequest request = new SingleSendMailRequest();
                    try
                    {
                        request.AccountName = fromEmail;
                        request.FromAlias = fromAlias;
                        request.AddressType = 1;
                        request.TagName = consoleTag;
                        request.ReplyToAddress = true;
                        request.ToAddress = _user.email;
                        request.Subject = mailContent.subject;
                        request.HtmlBody = string.Format(mailContent.content, _user.email_id, mailContent.msg_id);
                        SingleSendMailResponse httpResponse = client.GetAcsResponse(request);

                        var _reqId = httpResponse.RequestId;

                        //入库状态
                    }
                    catch (ServerException e)
                    {
                        //Console.WriteLine("服务器异常:" + e.Message);
                        //记录日志
                    }
                    catch (ClientException e)
                    {
                        //Console.WriteLine("客户端异常:" + e.Message);
                        //记录日志
                    }

                    Thread.Sleep(200);
                }

            }));
            _thread.Start(null);
        }
    }
}
