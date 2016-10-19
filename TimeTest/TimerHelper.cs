/*----------------------------------------------------------------
 *  Copyright (C) 2015 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：TimerHelper
 *  所属项目：
 *  创建用户：张德良
 *  创建时间：2016/4/21 星期四 下午 15:24:51
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
using System.Threading.Tasks;
using System.Timers;

namespace TimeTest
{
    public class TimerHelper
    {
        private Timer m_timer;
        public TimerHelper()
        {
            this.m_timer = new Timer();
        }

        private int _currentTimes = 0;

        /// <summary>
        /// 执行次数 0为不限制次数
        /// </summary>
        private int m_number = 0;
        public int Number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        private int m_timeDelay = 0;
        /// <summary>
        /// 延迟多少秒执行一次后再按间隔Interval执行
        /// </summary>
        public int TimeDelay
        {
            get { return m_timeDelay; }
            set { m_timeDelay = value; }
        }

        private int m_interval = 0;
        /// <summary>
        /// 每次执行间隔时间
        /// </summary>
        public int Interval
        {
            get { return m_interval; }
            set { m_interval = value; }
        }

        private bool m_enable = true;
        public bool Enable
        {
            get { return m_enable; }
            set { m_enable = value; }
        }

        private bool m_autoReset = true;
        public bool AutoReset
        {
            get { return m_autoReset; }
            set { m_autoReset = value; }
        }

        private bool m_isatOnce = false;
        /// <summary>
        /// 是否先立即执行一次
        /// </summary>
        public bool IsAtOnce
        {
            get { return m_isatOnce; }
            set { m_isatOnce = value; }
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        public event ElapsedEventHandler Elapsed;


        public void Start()
        {
            if (this.IsAtOnce && this.Elapsed != null)
            {
                this.Elapsed(this, null);
            }
            if (this.TimeDelay == 0)
            {
                m_timer.Interval = this.Interval;
                m_timer.Elapsed += (o, e) =>
                {
                    Elapsed(o, e);
                    this._currentTimes++;
                    if (this.Number > 0 && this._currentTimes == this.Number)
                    {
                        m_timer.Stop();
                    }
                };
            }
            else
            {
                m_timer.Interval = this.TimeDelay;
                m_timer.Elapsed += (o, e) =>
                {
                    Elapsed(o, e);
                    this._currentTimes++;
                    m_timer.Interval = this.Interval;
                    if (this.Number > 0 && this._currentTimes == this.Number)
                    {
                        m_timer.Stop();
                    }
                };
            }
            m_timer.Enabled = this.Enable;
            m_timer.AutoReset = this.AutoReset;
            m_timer.Start();
        }

        public void Stop()
        {
            m_timer.Stop();
        }
    }
}
