using LiteDB;
using LiteDbTest2;
using StochasticScenarioGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbAssist
{

    /// <summary>
    /// LiteDbContext 컨택스트 지원
    /// </summary>
    public class LiteDbContext : IDisposable
    {
        /// <summary>
        /// 연결 문자열
        /// </summary>
        public string ConnectString { get; private set; }

        /// <summary>
        /// 생성된 LiteDb 개체
        /// </summary>
        public LiteDatabase Database { get; private set; }

        /// <summary>
        /// 새로운 개체 생성
        /// </summary>
        /// <param name="sConnectString"></param>
        public LiteDbContext(string sConnectString)
        {
            this.ConnectString = sConnectString;

            this.Database = new LiteDatabase(this.ConnectString);
        }

        public void Dispose()
        {
            if (null != this.Database)
            {
                this.Database.Dispose();
                this.Database = null;
            }
        }

		#region LiteDb 전용 명령어

		#endregion

        /// <summary>
        /// 테스트용 모델
        /// </summary>
		public ILiteCollection<DataModel2> DataModel
		{
			get
			{
                if (null == DataModel_Ori)
                {
                    this.DataModel_Ori = this.Database.GetCollection<DataModel2>("DataModel2");
                }

                return this.DataModel_Ori;
            }
		}
        ILiteCollection<DataModel2> DataModel_Ori;

        /// <summary>
        /// 테스트용 모델
        /// </summary>
        //public LiteDbDataSet<DataModel> DataModel
        //{
        //    get
        //    {
        //        if (null == DataModel_Ori)
        //        {
        //            this.DataModel_Ori 
        //                = new LiteDbDataSet<DataModel>(
        //                    this.Database.GetCollection<DataModel>("DataModel"));
        //        }

        //        return this.DataModel_Ori;
        //    }
        //}

        //private LiteDbDataSet<DataModel> DataModel_Ori;



        public ILiteCollection<ScenarioBarItemModel> ScenarioBarItemModel
        {
            get
            {
                if (null == ScenarioBarItemModel_Ori)
                {
                    this.ScenarioBarItemModel_Ori 
                        = this.Database.GetCollection<ScenarioBarItemModel>("ScenarioBarItemModel");
                }

                return this.ScenarioBarItemModel_Ori;
            }
        }
        ILiteCollection<ScenarioBarItemModel> ScenarioBarItemModel_Ori;

    }
}
